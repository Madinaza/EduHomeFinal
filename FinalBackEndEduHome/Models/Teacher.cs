using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string MainImage { get; set; }
        [Required]
        public string DetailImage { get; set; }
        [Required, MaxLength(50)]
        public string FullName { get; set; }
        [Required, MaxLength(50)]
        public string Proffesion { get; set; }
        public string Title { get; set; }
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

        public  Contact Contacts { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
        [NotMapped]
        [Required]
        public IFormFile MainImageFile { get; set; }
        [NotMapped]
        [Required]
        public IFormFile DetailImageFile { get; set; }

    }
}
