using FinalBackEndEduHome.Areas.Dashboard.ViewModels;
using FinalBackEndEduHome.Constants;
using FinalBackEndEduHome.DAL;
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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if (!slider.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(slider.ImageFile), "This is unsupported,please select image");
                return View();
            }


            slider.Image = FileUtils.CreateFile(FileConstants.ImagePath, "slider", slider.ImageFile);
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, slider.Image));
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public IActionResult CreateMultiple()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(CreateMultpleSliderVM model)
        {
            if (!ModelState.IsValid) return View();

            foreach (var image in model.Images)
            {
                Slider slider = new Slider
                {
                    Title = model.Title,
                    Description = model.Desc,
  
                    Image = FileUtils.CreateFile(FileConstants.ImagePath, "slider", image),
                

                };
                await _context.Sliders.AddAsync(slider);
            };
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Update(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(int id, Slider slider)
        {
            var dbSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (dbSlider == null) return NotFound();
           
            if (!ModelState.IsValid) return View(slider);
            dbSlider.Title = slider.Title;
            dbSlider.Description = slider.Description;
            dbSlider.Image = FileUtils.CreateFile(FileConstants.ImagePath, "slider", slider.ImageFile);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Deteil(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }



    }
}
