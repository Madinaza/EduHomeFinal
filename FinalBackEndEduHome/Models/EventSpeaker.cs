namespace FinalBackEndEduHome.Models
{
    public class EventSpeaker
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int SpeakerId { get; set; }
        public Speaker speaker { get; set; }
        public Event Event { get; set; }
    }
}
