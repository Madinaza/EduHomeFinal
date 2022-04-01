using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Notice
    {

        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Heading { get; set; }

        [Required, MaxLength(500)]
        public string Desc { get; set; }
    }
}
