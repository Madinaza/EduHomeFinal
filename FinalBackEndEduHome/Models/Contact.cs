using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string FacebookURL { get; set; }
        public string PinterestURL { get; set; }

        public string InstagramURL { get; set; }
        public string TwitterURL { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
