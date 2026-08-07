
using DbMenagment;
using DbMenagment.Interfaces;
using DbMenagment.Services;
using Microsoft.EntityFrameworkCore;

namespace Shortly.Redirect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


            });
            builder.Services.AddScoped<IUrlService, UrlService>(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/{path}", async (string path, IUrlService urlService) =>
            {
                var urlObj = await urlService.GetOriginalUrl(path);

                if (urlObj != null)
                {
                    await urlService.incrementClicks(urlObj.Id);
                    return Results.Redirect(urlObj.OriginalLink);
                }

                return Results.Redirect("/");
            });

            app.Run();
        }
    }
}
