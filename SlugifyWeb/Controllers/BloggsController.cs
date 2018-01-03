using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SlugifyWeb.Data;
using SlugifyWeb.Models;

namespace SlugifyWeb.Controllers
{
    public class BloggsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloggsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bloggs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bloggs.ToListAsync());
        }

        // GET: Bloggs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Bloggs
                .SingleOrDefaultAsync(m => m.BloggID == id);
            if (blogg == null)
            {
                return NotFound();
            }

            return View(blogg);
        }

        // GET: Bloggs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bloggs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BloggID,Title")] Blogg blogg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogg);
        }

        // GET: Bloggs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Bloggs.SingleOrDefaultAsync(m => m.BloggID == id);
            if (blogg == null)
            {
                return NotFound();
            }
            return View(blogg);
        }

        // POST: Bloggs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BloggID,Title")] Blogg blogg)
        {
            if (id != blogg.BloggID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloggExists(blogg.BloggID))
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
            return View(blogg);
        }

        // GET: Bloggs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Bloggs
                .SingleOrDefaultAsync(m => m.BloggID == id);
            if (blogg == null)
            {
                return NotFound();
            }

            return View(blogg);
        }

        // POST: Bloggs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogg = await _context.Bloggs.SingleOrDefaultAsync(m => m.BloggID == id);
            _context.Bloggs.Remove(blogg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloggExists(int id)
        {
            return _context.Bloggs.Any(e => e.BloggID == id);
        }
    }
}
