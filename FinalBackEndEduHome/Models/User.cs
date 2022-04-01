using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Comment> Comment { get; set; }
        public List<Course> Course { get; set; }
        public List<Blog> Blog { get; set; }



    }
}
