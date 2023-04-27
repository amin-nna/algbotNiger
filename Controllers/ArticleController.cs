using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using algbotNiger.Areas.Identity.Data;
using algbotNiger.Models;

namespace algbotNiger.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Article
        public async Task<IActionResult> Index()
        {
              return _context.Articles != null ? 
                          View(await _context.Articles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }

        public async Task<IActionResult> IndexBlog()
        {
            return _context.Articles != null ?
                        PartialView(await _context.Articles.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }

        public async Task<IActionResult> IndexAdminHome()
        {
            return _context.Articles != null ?
                        View(await _context.Articles.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }

        public async Task<IActionResult> IndexAdmin()
        {
            return _context.Articles != null ?
                        PartialView(await _context.Articles.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }

        public async Task<IActionResult> IndexAdminHighlights()
        {
            return _context.Articles != null ?
                        PartialView(await _context.Articles.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }

        public async Task<IActionResult> IndexBlogHighlights()
        {
            return _context.Articles != null ?
                        PartialView(await _context.Articles.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }



        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        // GET: Article/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Preview,Content,Category,Highlight,MainImageSrc,PublishDate")] Articles articles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articles);
        }

        // GET: Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }
            return View(articles);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Preview,Content,Category,Highlight,MainImageSrc,PublishDate")] Articles articles)
        {
            if (id != articles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesExists(articles.Id))
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
            return View(articles);
        }

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articles == null)
            {
                return NotFound();
            }

            return View(articles);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
            }
            var articles = await _context.Articles.FindAsync(id);
            if (articles != null)
            {
                _context.Articles.Remove(articles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticlesExists(int id)
        {
          return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
