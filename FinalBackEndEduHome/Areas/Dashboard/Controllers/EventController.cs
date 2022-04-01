using FinalBackEndEduHome.Areas.Dashboard.ViewModels;
using FinalBackEndEduHome.Constants;
using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.Extensions;
using FinalBackEndEduHome.Migrations;
using FinalBackEndEduHome.Models;
using FinalBackEndEduHome.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class EventController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Event> events = await _context.Events.ToListAsync();
            return View(events);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Event events = await _context.Events.FindAsync(id);

            EventTVM model = new EventTVM
            {
                Event = events,
                Speakers = await _context.Speakers.Include(c => c.eventSpeakers).
                Where(c => c.eventSpeakers.Select(c => c.EventId).Contains(id)).ToListAsync(),
            };

            return View(model);
        }


        public async Task<IActionResult> Create()
        {
            EventPostVM model = new EventPostVM
            {
                Speakers = await _context.Speakers.ToListAsync(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventPostVM model)
        {
            model.Speakers = await _context.Speakers.ToListAsync();
            

            List<EventSpeaker> speakers = new List<EventSpeaker>();
            foreach (var speakerId in model.SpeakerIds)
            {
                var speaker = await _context.Speakers.FindAsync(speakerId);
                if (speaker == null)
                {
                    ModelState.AddModelError(nameof(EventPostVM.SpeakerIds), "Choose a valid speaker");
                    return View(model);
                }
                speakers.Add(new EventSpeaker { SpeakerId = speakerId });
            }

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(EventPostVM.Image), "There is a problem in your file");
                return View(model);
            }

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(EventPostVM.Detailimg), "There is a problem in your file");
                return View(model);
            }

            model.Image = FileUtils.CreateFile(FileConstants.ImagePath,"event", model.ImageFile);
            model.Detailimg = FileUtils.CreateFile(FileConstants.ImagePath, "event", model.DetailImgFILE);



            Event eventt = new Event
            {
                Title = model.Title,
                Desc = model.Description,
                Venue = model.venur,
                Date = model.Date,
              
                MainImage = FileUtils.CreateFile(FileConstants.ImagePath,"event", model.ImageFile),
                DetailImage = FileUtils.CreateFile(FileConstants.ImagePath, "event", model.DetailImgFILE),

                eventSpeakers = speakers
            };

            await _context.Events.AddAsync(eventt);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> Delete(int id)
        {
            Event events = await _context.Events.FindAsync(id);

            EventTVM model = new EventTVM
            {
                Event = events,
                Speakers = await _context.Speakers.Include(c => c.eventSpeakers).
                Where(c => c.eventSpeakers.Select(c => c.EventId).Contains(id)).ToListAsync(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventt = await _context.Events.Include(f => f.eventSpeakers).ThenInclude(fc => fc.speaker).FirstOrDefaultAsync(f => f.Id == id);
            if (eventt == null) return NotFound();


            FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath,"event", eventt.MainImage));
            _context.Remove(eventt);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }



}
