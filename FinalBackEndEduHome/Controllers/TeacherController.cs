using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.Models;
using FinalBackEndEduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = await _context.Teachers.Include(c => c.Contacts).ToListAsync();
            return View(teachers);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Teacher teachers = await _context.Teachers.Include(c => c.Contacts).Include(t=>t.TeacherSkills).FirstOrDefaultAsync(c => c.Id == id);
            if (teachers == null) return NotFound();

            TeacherVM teachervm = new TeacherVM()
            {
                Teacher = teachers,
                TeacherContact = await _context.Contacts.FirstOrDefaultAsync(f => f.TeacherId == id),
            };
            return View(teachervm);
        }

       
    }
}
