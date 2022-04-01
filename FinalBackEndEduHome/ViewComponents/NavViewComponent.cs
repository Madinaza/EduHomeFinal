﻿using FinalBackEndEduHome.DAL;
using FinalBackEndEduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBackEndEduHome.ViewComponents
{
    public class NavViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;


        public NavViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Layout layout = await _context.Layouts.FirstOrDefaultAsync();
            return View(layout);
        }
    }
}
