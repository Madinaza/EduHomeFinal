using FinalBackEndEduHome.Areas.Dashboard.ViewModels.Teacher;
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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var teacher = await _context.Teachers.Select(t => new TeacherListVM {
                Id=t.Id,
                FullName=t.FullName,
                Proffession=t.Proffesion,
                MainImage=t.MainImage
            
            }).ToListAsync();
            return View(teacher);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var teacher = await _context.Teachers.Include(x => x.TeacherSkills).ThenInclude(s => s.Skill).FirstOrDefaultAsync(c => c.Id == id);


            TeacherListVM model = new TeacherListVM
            {
                FullName=teacher.FullName,
                Degree=teacher.Degree,
                Hobbies=teacher.Hobbies,
                Experience=teacher.Experience,
                Faculty=teacher.Faculty,

                DetailImage = teacher.DetailImage,

                TeacherContact = await _context.Contacts.FirstOrDefaultAsync(f => f.TeacherId == id),
               
            };
            return View(model);
        }



     

        public async Task<IActionResult> Create()
        {
            TeacherPostVm model = new TeacherPostVm
            {
                Skills = await _context.Skills.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherPostVm model)
        {
            model.Skills = await _context.Skills.ToListAsync();

            
            List<TeacherSkill> skills = new List<TeacherSkill>();
            foreach (var skillId in model.SkillIds)
            {
                var skill = await _context.Skills.FindAsync(skillId);
                if (skill == null)
                {
                    ModelState.AddModelError(nameof(TeacherPostVm.SkillIds), "Choose a valid skill");
                    return View(model);
                }
                skills.Add(new TeacherSkill { SkillId = skillId });
            };

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(TeacherPostVm.ImageFile), "There is a problem in your file");
                return View(model);
            };


            Teacher teacher = new Teacher
            {
                FullName = model.Fullname,
                About = model.About,
                Hobbies = model.Hobbies,
                Experience = model.Experience,
                Degree = model.Degree,
                Faculty = model.Faculty,
               Proffesion=model.Proffesion,
                Contacts = model.TeacherContact,
                MainImage = FileUtils.CreateFile(FileConstants.ImagePath,"teacher", model.ImageFile),
                DetailImage = FileUtils.CreateFile(FileConstants.ImagePath, "teacher", model.DetailimgFile),


                TeacherSkills = skills,

            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.Include(c => c.Contacts)
                .Include(s => s.TeacherSkills).FirstOrDefaultAsync(c => c.Id == id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.Include(c => c.Contacts)
                .Include(s => s.TeacherSkills).FirstOrDefaultAsync(c => c.Id == id);
            if (teacher == null) return NotFound();
            FileUtils.DeleteFile(Path.Combine(FileConstants.ImagePath, teacher.MainImage));
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }







    }
}
