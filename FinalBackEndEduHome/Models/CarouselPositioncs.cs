using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class CarouselPositioncs
    {
        public int Id { get; set; }
        public int CarouselId { get; set; }
        public int PossitionId { get; set; }
        public Carousel carousel { get; set; }
        public Possition possition { get; set; }
    }
}
