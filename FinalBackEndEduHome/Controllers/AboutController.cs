using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM model = new AboutVM()
            {
                Welcomes = await _context.WelcomeEdus.ToListAsync(),
                Carousels = await _context.Carousels.Include(c => c.CarouselPositioncs)
                .ThenInclude(pc => pc.possition).ToListAsync(),
                Possitions = await _context.Possitions.Include(p => p.CarouselPositioncs).
                ThenInclude(pc => pc.carousel).ToListAsync(),
                Notices = await _context.NoticeBoards.ToListAsync(),
                Teachers = await _context.Teachers.Include(c => c.Contacts).Include(t => t.TeacherSkills).Take(4).ToListAsync()



            };
            return View(model);
        }
    }
}
