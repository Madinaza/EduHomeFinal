using FinalBackEndEduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Carousel> Carousels { get; set; }
        public List<Possition> Possitions { get; set; }

        public List<Notice> Notices { get; set; }
        public List<IndexAbout> IndexAbouts { get; set; }
        public List<Course> Courses { get; set; }

        public List<Blog> Blogs { get; set; }
        public List<WhyChoose> WhyChooses { get; set; }
        public List<Event> Events { get; set; }

    }
}
