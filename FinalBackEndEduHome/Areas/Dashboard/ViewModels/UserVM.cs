namespace FinalBackEndEduHome.Areas.Dashboard.ViewModels
{
    public class UserVM
    {
         public string Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Roles { get; set; }
        public bool IsActive { get; set; }
    }
}
