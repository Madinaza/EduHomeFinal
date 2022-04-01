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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }



        public async Task<IActionResult> Index()
        {
            var blog = await _context.Blogs.ToListAsync();
            return View(blog);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null) return NotFound();
            return View(blog);

        }


        public async Task<IActionResult> Delete(int id)
        {
            Blog blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            return View(blog);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            Blog blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, blog.Image));
            FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, blog.DetailImage));

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }



        public IActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogVM blog)
        {
            if (!ModelState.IsValid) return View(blog);
            if (!blog.ImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(blog.ImageFile), "This is unsupported,please select image");
                return View();
            }
          

            if (!blog.DetailImageFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError(nameof(blog.DetailImageFile), "This is unsupported,please select image");
                return View();
            }




            Blog nblog = new Blog
            {
                Title = blog.Title,
                Description = blog.Description,
                Author = blog.Author,
                Date = blog.Date,
                Image = FileUtils.CreateFile(FileConstants.ImagePath, "blog", blog.ImageFile),
                DetailImage = FileUtils.CreateFile(FileConstants.ImagePath, "blog", blog.DetailImageFile),


            };
            await _context.Blogs.AddAsync(nblog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();



            BlogVM nblog = new BlogVM
            {
                Title = blog.Title,
                Description = blog.Description,
                Author = blog.Author,
                Date = blog.Date,
               

            };



            return View(nblog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BlogVM blog)
        {
            var dbBlog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (dbBlog == null) return NotFound();
        

            if (!ModelState.IsValid) return View(blog);
            //if (blog.Image != null)
            //{

            //    FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, "blog", blog.Image));
            //}
            //if (blog.DetailImage != null)
            //{

            //    FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, "blog", blog.DetailImage));
            //}


            //if (blog.Image != null)
            //{
            //    if (!blog.Image.isOkay())
            //    {
            //        ModelState.AddModelError(nameof(BlogVM.Image), "There is a problem in your file");
            //        return View(model);
            //    }
            //    FileUtils.Delete(Path.Combine(FileConstants.ImagePath, flower.MainImage));
            //}


            dbBlog.Title = blog.Title;
            dbBlog.Description = blog.Description;
            dbBlog.Image = FileUtils.CreateFile(FileConstants.ImagePath, "blog", blog.ImageFile);
            dbBlog.DetailImage = FileUtils.CreateFile(FileConstants.ImagePath, "blog", blog.DetailImageFile);
            dbBlog.Author = blog.Author;
            dbBlog.Date = blog.Date;
            //dbBlog.Image = blog.Image != null ? FileUtils.CreateFile(FileConstants.ImagePath, "blog", blog.ImageFile) : blog.Image;
            //dbBlog.DetailImage = blog.DetailImage != null ? FileUtils.CreateFile(FileConstants.ImagePath, "blog", blog.DetailImageFile) : blog.DetailImage;



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
