using FinalBackEndEduHome.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class CoursePostVM
    {
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        public string DetailImg { get; set; }
        public string Description { get; set; }
        
        public CourseFeature Feature { get; set; }
        public List<Category> Category { get; set; }
        public int? FeatureId { get; set; }
        public List<int> CategoryIds { get; set; }
        public IFormFile ImageFile { get; set; }
        public IFormFile DetailImgFile { get; set; }


    }
}
