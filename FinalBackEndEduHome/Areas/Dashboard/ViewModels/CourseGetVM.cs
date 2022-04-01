using FinalBackEndEduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class CourseGetVM
    {
        public Course Course { get; set; }
        public List<Category> Categories { get; set; }
        public List<int> CategoryIds { get; set; }
        public CourseFeature Feature { get; set; }
    }
}
