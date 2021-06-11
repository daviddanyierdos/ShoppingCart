﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        readonly ShoppingCartContext context;

        public PagesController(ShoppingCartContext context)
        {
            this.context = context;
        }

        // GET admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;

            List<Page> pageList = await pages.ToListAsync();

            return View(pageList);
        }      
        
        // GET admin/pages/details/5
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync<Page>(x => x.Id == id);

            if (page == null) return NotFound();

            return View(page);
        }
    }
}