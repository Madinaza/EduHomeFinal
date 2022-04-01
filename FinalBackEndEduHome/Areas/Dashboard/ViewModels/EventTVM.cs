using FinalBackEndEduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class EventTVM
    {

        public Event Event { get; set; }
        public List<Speaker> Speakers { get; set; }
        public List<int> SpeakerIds { get; set; }
    }
}
