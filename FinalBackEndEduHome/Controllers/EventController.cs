using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.Migrations;
using FinalBackEndEduHome.Models;
using FinalBackEndEduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Event> events = await _context.Events.Include(s=>s.eventSpeakers).ThenInclude(e=>e.speaker).ToListAsync();
            if (events == null) NotFound();
            return View(events);
        }

        public async Task<IActionResult> Detail(int id)
        {
            EventVM model = new EventVM
            {
                Events=await _context.Events.Include(s=>s.eventSpeakers).ThenInclude(e=>e.speaker).FirstOrDefaultAsync(),
                SpeakerPositions=await _context.SpeakerPositions.Include(S=>S.possition).Include(e=>e.speaker).ToListAsync(),
                Possitions=await _context.Possitions.ToListAsync(),
                Speakers=await _context.Speakers.ToListAsync(),


            };
            return View(model);

        }

    }
}
