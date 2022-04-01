using FinalBackEndEduHome.Areas.Dashboard.ViewModels;
using FinalBackEndEduHome.Constants;
using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.Extensions;
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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses.ToListAsync();
            return View(courses);

        }

        public async Task<IActionResult> Detail(int id)
        {
            var course = await _context.Courses.Include(c => c.Feature).Include(f => f.CourseCategories)
                   .ThenInclude(fc => fc.Category).AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

            if (course == null) return NotFound();

            return View(course);
        }

        public async Task<IActionResult> Update(int id)
        {
            var course = await _context.Courses.Include(t => t.CourseCategories).ThenInclude(t => t.Category).FirstOrDefaultAsync(f => f.Id == id);
            if (course == null) return NotFound();

            List<Category> cts = new List<Category>();
            foreach (var item in course.CourseCategories)
            {
                cts.Add(item.Category);
            }

            CourseGetVM model = new CourseGetVM();

            model.Course = course;
            model.Feature = await _context.CourseFeatures.FirstOrDefaultAsync(f => f.CourseId == id);
            model.Categories = _context.Categories.ToList();
            model.CategoryIds = cts.Select(x => x.Id).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CourseGetVM model)
        {

            List<Category> categories1 = new List<Category>();

            var oldCategoryIds = await _context.CourseCategories.Where(x => x.CourseId == model.Course.Id).Select(x => x.CategoryId).ToListAsync();

            foreach (var oldId in oldCategoryIds)
            {
                var oldCourseCat = await _context.CourseCategories.FirstOrDefaultAsync(x => x.CategoryId == oldId && x.CourseId == model.Course.Id);
                _context.CourseCategories.Remove(oldCourseCat);
            }

            foreach (var newId in model.CategoryIds)
            {
                CourseCategory crsCat = new CourseCategory() { CourseId = model.Course.Id, CategoryId = newId };
                await _context.CourseCategories.AddAsync(crsCat);
            }



            if (!model.Course.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(Course.ImageFile), "File type is unsupported, please select image");
                return View();
            }

            if (!model.Course.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(Course.DetailImgFile), "File type is unsupported, please select image");
                return View();
            }



            model.Course.Image = FileUtils.CreateFile(FileConstants.ImagePath, "course", model.Course.ImageFile);
            model.Course.DetailImg = FileUtils.CreateFile(FileConstants.ImagePath, "course", model.Course.DetailImgFile);

            CoursePostVM vm = new CoursePostVM
            {

                Category = await _context.Categories.Include(c => c.CourseCategories).ThenInclude(s => s.Category)
                .Where(c => c.CourseCategories.Select(c => c.CourseId).Contains(id)).ToListAsync(),
                Feature = await _context.CourseFeatures.FirstOrDefaultAsync(f => f.CourseId == id),
                Title=model.Course.Title,
                Description = model.Course.Description,


            };

            bool isExist = await _context.Courses.AnyAsync(l => l.Id == id);
            if (!isExist) return NotFound();

            _context.Courses.Update(model.Course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            CoursePostVM model = new CoursePostVM
            {
                Category = await _context.Categories.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoursePostVM model)
        {
            model.Category = await _context.Categories.ToListAsync();
         

            List<CourseCategory> categories = new List<CourseCategory>();
            foreach (var categoryId in model.CategoryIds)
            {
                var category = await _context.Speakers.FindAsync(categoryId);
                
                categories.Add(new CourseCategory { CategoryId = categoryId });
            }

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(CoursePostVM.Image), "There is a problem in your file");
                return View(model);
            }

            model.Image = FileUtils.CreateFile(FileConstants.ImagePath, "course", model.ImageFile);
            model.DetailImg = FileUtils.CreateFile(FileConstants.ImagePath, "course", model.DetailImgFile);


            Course course = new Course
            {
                Title = model.Title,
             
                Feature = model.Feature,
                Image = FileUtils.CreateFile(FileConstants.ImagePath,"assets", model.ImageFile),
                DetailImg = FileUtils.CreateFile(FileConstants.ImagePath, "assets", model.DetailImgFile),

                CourseCategories = categories
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.Include(c => c.Feature).Include(f => f.CourseCategories)
                  .ThenInclude(fc => fc.Category).AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

            if (course == null) return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.Include(c => c.Feature).Include(f => f.CourseCategories)
                 .ThenInclude(fc => fc.Category).AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

            if (course == null) return NotFound();

            FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, course.Image));
            _context.Remove(course);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

