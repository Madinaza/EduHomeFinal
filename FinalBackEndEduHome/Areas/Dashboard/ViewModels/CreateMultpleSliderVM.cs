using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class CreateMultpleSliderVM
    {
      public string Title { get; set; }

        public string Desc { get; set; }
        [Required]
        public IFormFile[] Images { get; set; }
    }
}
