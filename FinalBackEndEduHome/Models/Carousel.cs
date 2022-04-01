using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Carousel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public List<CarouselPositioncs> CarouselPositioncs { get; set; }
    }
}
