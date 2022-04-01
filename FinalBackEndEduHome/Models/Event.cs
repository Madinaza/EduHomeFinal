using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MainImage { get; set; }
        public string DetailImage { get; set; }

        public string Title { get; set; }   
        public string City { get; set; }
        public string Venue { get; set; }
        public string Desc { get; set; }
        public List<EventSpeaker> eventSpeakers { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }




    }
}
