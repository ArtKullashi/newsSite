using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ubtnews.Data;
using ubtnews.Models;
using ubtnews.Models.Home;

namespace ubtnews.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var articles = _context.Articles.Include(a => a.ArticleCategories).AsNoTracking();
            int pageSize= 3;

            var vm = new IndexViewModel
            {
                Articles = await PaginatedList<Article>.CreateAsync(articles, page ?? 1, pageSize)
            };
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Message";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult testi()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
