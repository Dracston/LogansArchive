using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogansArchive.Data;
using LogansArchive.Models;

namespace LogansArchive.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MainArchiveContext _context;

        public DirectorsController(MainArchiveContext context)
        {
            _context = context;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            var mainArchiveContext = _context.Directors.Include(d => d.Movie).Include(d => d.Show);
            return View(await mainArchiveContext.ToListAsync());
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .Include(d => d.Movie)
                .Include(d => d.Show)
                .FirstOrDefaultAsync(m => m.directorId == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "Director");
            ViewData["showId"] = new SelectList(_context.Shows, "showId", "Director");
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("directorId,showId,movieId,Name,Age")] Director director)
        {
            if (ModelState.IsValid)
            {
                _context.Add(director);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "Director", director.movieId);
            ViewData["showId"] = new SelectList(_context.Shows, "showId", "Director", director.showId);
            return View(director);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "Director", director.movieId);
            ViewData["showId"] = new SelectList(_context.Shows, "showId", "Director", director.showId);
            return View(director);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("directorId,showId,movieId,Name,Age")] Director director)
        {
            if (id != director.directorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.directorId))
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
            ViewData["movieId"] = new SelectList(_context.Movies, "movieId", "Director", director.movieId);
            ViewData["showId"] = new SelectList(_context.Shows, "showId", "Director", director.showId);
            return View(director);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .Include(d => d.Movie)
                .Include(d => d.Show)
                .FirstOrDefaultAsync(m => m.directorId == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director != null)
            {
                _context.Directors.Remove(director);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
            return _context.Directors.Any(e => e.directorId == id);
        }
    }
}
