using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        readonly ShoppingCartContext context;
        public ProductsController(ShoppingCartContext context)
        {
            this.context = context;
        }

        // GET /admin/products
        public async Task<IActionResult> Index()
        {
            return View(await context.Products.OrderByDescending(x => x.Id).Include(x => x.Category).ToListAsync());
        }
    }
}
