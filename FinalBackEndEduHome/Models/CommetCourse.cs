namespace FinalBackEndEduHome.Models
{
    public class CommetCourse:BaseEntity
    {

        public string Description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
