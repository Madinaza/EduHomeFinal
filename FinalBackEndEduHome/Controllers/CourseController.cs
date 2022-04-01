using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.Models;
using FinalBackEndEduHome.Services;
using FinalBackEndEduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMailService _mailService;

        public CourseController(AppDbContext context, UserManager<User> userManager, IMailService mailService)
        {
            _userManager = userManager;
            _context = context;
            _mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            var course = await _context.Courses.Include(c => c.Feature).ToListAsync();

            return View(course);

        }

        public async Task<IActionResult> Detail(int id)
        {
            Course course = await _context.Courses.Include(c => c.Feature).Include(f => f.CourseCategories)
                .ThenInclude(fc => fc.Category)
                .Include(cm => cm.CommentsCourse).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();
            CourseCommentVM model = new CourseCommentVM
            {
                Course = course,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> AddComment(int id, CourseCommentVM model)
        {

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return NotFound();

            if (!ModelState.IsValid)
            {
                model.Course = course;
                return View(model);
            }

            var comment = new CommetCourse
            {
                Description = model.Comment.Desc,
                UserId = _userManager.GetUserId(User),
                CourseId = id
            };

            await _context.CommentsCourses.AddAsync(comment);
            await _context.SaveChangesAsync();

            //await _mailService.SendEmailAsync(new MailRequest
            //{
            //    ToEmail = blog.User.Email,
            //    Subject = "New Comment",
            //    Body = $"new comment to your {flower.Name} flower: {comment.Description}"
            //});

            return RedirectToAction(nameof(Detail), new { id });
        }


    }
}
