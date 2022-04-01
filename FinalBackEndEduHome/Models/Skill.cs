using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string SkillName { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
