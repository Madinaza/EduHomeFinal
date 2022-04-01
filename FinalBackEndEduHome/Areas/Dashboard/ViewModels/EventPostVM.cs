using FinalBackEndEduHome.Migrations;
using FinalBackEndEduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class EventPostVM
    {

        [Required]
        [StringLength(maximumLength: 50)]
        public string Image { get; set; }

        public string Detailimg { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
       
        [Required]
        [StringLength(maximumLength: 50)]
        public string venur { get; set; }
        public List<int> SpeakerIds { get; set; }
        public List<Speaker> Speakers { get; set; }
        public IFormFile ImageFile { get; set; }
        public IFormFile DetailImgFILE { get; set; }

    }
}
