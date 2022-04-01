using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [Required]
        public string Title { get; set; }
        

        public string Description { get; set; }
        public byte Order { get; set; }

        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
