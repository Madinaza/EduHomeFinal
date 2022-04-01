using FinalBackEndEduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels.Teacher
{
    public class TeacherPostVm
    {
        [Required]
        [StringLength(maximumLength: 200)]
        public string Fullname { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Proffesion { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string About { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Degree { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Experience { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Hobbies { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Faculty { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Image { get; set; }
        public List<int> SkillIds { get; set; }
        public int TeacherContactId { get; set; }
        public IFormFile ImageFile { get; set; }
        public IFormFile DetailimgFile { get; set; }

        public string DetailImage { get; set; }

        public Contact TeacherContact { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
