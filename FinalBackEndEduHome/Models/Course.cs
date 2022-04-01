using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        public string DetailImg { get; set; }
        [Required]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Required]
        [NotMapped]
        public IFormFile DetailImgFile { get; set; }
        public string Description { get; set; }
    
        public List<CommetCourse> CommentsCourse{ get; set; }
        public CourseFeature Feature { get; set; }

        public List<CourseCategory> CourseCategories{ get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
