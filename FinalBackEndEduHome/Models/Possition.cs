using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Possition
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarouselPositioncs> CarouselPositioncs { get; set; }
        public List<SpeakerPosition> speakerPositions { get; set; }

    }
}
