namespace FinalBackEndEduHome.Models
{
    public class SpeakerPosition
    {
        public int Id { get; set; }
        public int SpeakerId { get; set; }
        public int PossitionId { get; set; }
        public Speaker speaker { get; set; }
        public Possition possition { get; set; }
    }
}
