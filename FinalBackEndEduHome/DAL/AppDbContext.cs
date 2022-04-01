using FinalBackEndEduHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Possition> Possitions { get; set; }
        public DbSet<CarouselPositioncs> CarouselPositioncs { get; set; }
        public DbSet<Notice> NoticeBoards { get; set; }
        public DbSet<IndexAbout> IndexAbouts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseFeature> CourseFeatures { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<WhyChoose> WhyChoose { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<SpeakerPosition> SpeakerPositions { get; set; }
        public DbSet<WelcomeEdu> WelcomeEdus { get; set; }
       public DbSet<Comment> Comments { get; set; }
        public DbSet<CommetCourse> CommentsCourses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }

        public DbSet<Layout> Layouts { get; set; }








    }
}
