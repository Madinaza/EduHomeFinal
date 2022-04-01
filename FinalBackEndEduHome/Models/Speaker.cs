using System.Collections.Generic;

namespace FinalBackEndEduHome.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }

        public List<SpeakerPosition> speakerPositions { get; set; }
        public List<EventSpeaker> eventSpeakers { get; set; }

    }

}
