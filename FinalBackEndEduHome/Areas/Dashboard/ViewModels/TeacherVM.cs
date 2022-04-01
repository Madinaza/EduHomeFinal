using FinalBackEndEduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels.Teacher
{
    public class TeacherListVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Proffession { get; set; }
        public string MainImage { get; set; }
        public string DetailImage { get; set; }
        public string About { get; set; }
       
        public string Degree { get; set; }
      
        public string Experience { get; set; }
       
        public string Hobbies { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }

        public string Faculty { get; set; }
        public Contact TeacherContact { get; set; }
        public List<Skill> Skills { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
