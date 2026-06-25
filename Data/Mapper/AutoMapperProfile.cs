using AutoMapper;
using DbMenagment.Models;
using ShortUrl.Data.ViewModel;

namespace ShortUrl.Data.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Url, GetUrl>().ReverseMap();
            CreateMap<User, GetUserVM>().ReverseMap();
        }
    }
}
