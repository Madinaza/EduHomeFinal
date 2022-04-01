using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Layout
    {
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
        [Column("Intagram")]
        public string InstagramUrl { get; set; }
        [Column("Facebook")]
        public string FacebookUrl { get; set; }
        [Column("Pinterest")]
        public string PinteresUrl { get; set; }
        [Column("Twitter")]
        public string TwitterUrl { get; set; }
    }
}
