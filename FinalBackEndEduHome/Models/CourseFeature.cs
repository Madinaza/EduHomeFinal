using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class CourseFeature
    {
        public int Id { get; set; }
        public DateTime Starts { get; set; }
        [Required]

        public string Duration { get; set; }
        [Required]

        public string ClassDuration { get; set; }
        [Required]

        public string SkillLevel { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]

        public string Student { get; set; }
        [Required]

        public string Assements {get; set; }
        [Required]
        public double Price { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
 }

