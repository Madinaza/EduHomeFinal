using FinalBackEndEduHome.Migrations;
using FinalBackEndEduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.ViewModels
{
    public class EventVM
    {
        public      Event Events{ get; set; }
        public List<Speaker> Speakers { get; set; }
        public List<SpeakerPosition> SpeakerPositions { get; set; }
        public List<Possition> Possitions { get; set; }


    }
}
