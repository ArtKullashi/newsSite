using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ubtnews.Areas.Admin.Models.Articles;
using ubtnews.Data;
using ubtnews.Models;
using System.IO;


namespace ubtnews.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        public ArticlesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/Articles
        public async Task<IActionResult> Index(string term)
        {
            var articles = User.IsInRole("Administrator") ? await _context.Articles.ToListAsync() : await _context.Articles
                                .Where(a => a.Permissions.Exists(au => au.UserId == CurrentUserId))
                                .ToListAsync();
            var articlesToReturn = new List<Article>();
            for(int i = 0; i < articles.Count; i++)
            {
                if (articles[i].Title.Contains(term ?? "") || articles[i].Body.Contains(term ?? ""))
                {
                    articlesToReturn.Add(articles[i]);
                }
            }
            return View(articlesToReturn);
        }

        // GET: Admin/Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!await HasAccessToArticle(id.Value))
            {
                return View("Error");
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Admin/Articles/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);

                _context.Permissions.Add(new Permission
                {
                    UserId = CurrentUserId,
                    Article = article
                });

                

                _context.Add(article);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!await HasAccessToArticle(id.Value))
            {
                return View("Error");
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Article article, IFormFile imageFile)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (!await HasAccessToArticle(id))
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null)
                    {
                        var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
                        var fileDirectory = "wwwroot/images";

                        if (!Directory.Exists(fileDirectory))
                        {
                            Directory.CreateDirectory(fileDirectory);
                        }

                        var filePath = fileDirectory + "/" + fileName;

                        // Copy file to path...
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        article.Img = fileName;
                    }
                    else
                    {

                    }
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!await HasAccessToArticle(id.Value))
            {
                return View("Error");
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await HasAccessToArticle(id))
            {
                return View("Error");
            }

            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ManageUsers(int id)
        {
            var article = await _context.Articles
                                .Include(a => a.Permissions)
                                .ThenInclude(au => au.User)
                                .SingleOrDefaultAsync(a => a.Id == id);

            var allUsers = await _userManager.GetUsersInRoleAsync("NormalUser");

            var vm = new ManageUsersViewModel();
            vm.Id = id;
            vm.AssignedUsers = article.Permissions.Select(au => au.User);
            vm.AvailableUsers = allUsers.Where(u => !vm.AssignedUsers.Any(x => x.Id == u.Id));

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddUserToArticle(int id, string userId)
        {
            _context.Permissions.Add(new Permission
            {
                ArticleId = id,
                UserId = userId
            });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageUsers), new { id = id });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveUserFromArticle(int id, string userId)
        {
            var au = await _context.Permissions.SingleOrDefaultAsync(a => a.UserId == userId && a.ArticleId == id);

            if (au != null)
            {
                _context.Permissions.Remove(au);

                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(ManageUsers), new { id = id });
        }

        private async Task<bool> HasAccessToArticle(int articleId)
        {
            if (User.IsInRole("Administrator"))
                return true;

            var article = await _context.Articles
                                .Where(a => a.Id == articleId)
                                .Where(a => a.Permissions.Exists(au => au.UserId == CurrentUserId))
                                .SingleOrDefaultAsync();

            return article != null;
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}