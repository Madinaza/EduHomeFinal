using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class BlogVM
    {
       
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Image { get; set; }
        public string DetailImage { get; set; }

        public IFormFile ImageFile { get; set; }
      
        public IFormFile DetailImageFile { get; set; }

    }
}
