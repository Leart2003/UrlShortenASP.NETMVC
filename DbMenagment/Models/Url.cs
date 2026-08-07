using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMenagment.Models
{
   
    
        public class Url
        {

            public int Id { get; set; }


            public string OriginalLink { get; set; }


            public string ShortLink { get; set; }

            public int ClickedTime { get; set; }

            public string? UserID { get; set; }

            public DateTime CreationDate { get; set; }

            public DateTime UpdatedDate { get; set; }

            public AppUser User { get; set; }
        }
    }



