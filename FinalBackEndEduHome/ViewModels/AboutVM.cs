using FinalBackEndEduHome.Models;
using System.Collections.Generic;

namespace FinalBackEndEduHome.ViewModels
{
    public class AboutVM
    {
        public List<Teacher> Teachers { get; set; }
        public List<Carousel> Carousels { get; set; }
        public List<Notice> Notices { get; set; }
        public List<WelcomeEdu> Welcomes { get; set; }
        public List<Possition> Possitions { get; set; }


    }
}
