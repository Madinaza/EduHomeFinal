using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.Models;
using FinalBackEndEduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Sliders = await _context.Sliders.OrderBy(s => s.Order).ToListAsync(),
                Carousels = await _context.Carousels.Include(c => c.CarouselPositioncs)
                .ThenInclude(pc => pc.possition).ToListAsync(),
                Possitions = await _context.Possitions.Include(p => p.CarouselPositioncs).
                ThenInclude(pc => pc.carousel).ToListAsync(),
                Notices = await _context.NoticeBoards.ToListAsync(),
                IndexAbouts = await _context.IndexAbouts.ToListAsync(),
                Courses = await _context.Courses.Include(c => c.Feature).Take(3).ToListAsync(),
                Blogs = await _context.Blogs.Take(3).ToListAsync(),
                WhyChooses=await _context.WhyChoose.ToListAsync(),
                Events=await _context.Events.Take(8).OrderByDescending(e=>e.Id).ToListAsync(),



            };
            return View(model);
        }

    }
}
