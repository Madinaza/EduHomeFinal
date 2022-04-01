namespace FinalBackEndEduHome.Models
{
    public class Comment:BaseEntity
    {
        
        public string Description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
