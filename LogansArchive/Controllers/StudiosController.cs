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
    public class StudiosController : Controller
    {
        private readonly MainArchiveContext _context;

        public StudiosController(MainArchiveContext context)
        {
            _context = context;
        }

        // GET: Studios
        public async Task<IActionResult> Index()
        {
            var mainArchiveContext = _context.Studios.Include(s => s.Game);
            return View(await mainArchiveContext.ToListAsync());
        }

        // GET: Studios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studio = await _context.Studios
                .Include(s => s.Game)
                .FirstOrDefaultAsync(m => m.studioId == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // GET: Studios/Create
        public IActionResult Create()
        {
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console");
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studioId,gameId,Name,yearEstablished,Address")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console", studio.gameId);
            return View(studio);
        }

        // GET: Studios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studio = await _context.Studios.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console", studio.gameId);
            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("studioId,gameId,Name,yearEstablished,Address")] Studio studio)
        {
            if (id != studio.studioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudioExists(studio.studioId))
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
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console", studio.gameId);
            return View(studio);
        }

        // GET: Studios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studio = await _context.Studios
                .Include(s => s.Game)
                .FirstOrDefaultAsync(m => m.studioId == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studio = await _context.Studios.FindAsync(id);
            if (studio != null)
            {
                _context.Studios.Remove(studio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudioExists(int id)
        {
            return _context.Studios.Any(e => e.studioId == id);
        }
    }
}
