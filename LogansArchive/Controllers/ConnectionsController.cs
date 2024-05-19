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
    public class ConnectionsController : Controller
    {
        private readonly MainArchiveContext _context;

        public ConnectionsController(MainArchiveContext context)
        {
            _context = context;
        }

        // GET: Connections
        public async Task<IActionResult> Index()
        {
            var mainArchiveContext = _context.Connections.Include(c => c.Game).Include(c => c.Studio);
            return View(await mainArchiveContext.ToListAsync());
        }

        // GET: Connections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connection = await _context.Connections
                .Include(c => c.Game)
                .Include(c => c.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (connection == null)
            {
                return NotFound();
            }

            return View(connection);
        }

        // GET: Connections/Create
        public IActionResult Create()
        {
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console");
            ViewData["studioId"] = new SelectList(_context.Studios, "studioId", "Address");
            return View();
        }

        // POST: Connections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,gameId,studioId")] Connection connection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(connection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console", connection.gameId);
            ViewData["studioId"] = new SelectList(_context.Studios, "studioId", "Address", connection.studioId);
            return View(connection);
        }

        // GET: Connections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connection = await _context.Connections.FindAsync(id);
            if (connection == null)
            {
                return NotFound();
            }
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console", connection.gameId);
            ViewData["studioId"] = new SelectList(_context.Studios, "studioId", "Address", connection.studioId);
            return View(connection);
        }

        // POST: Connections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,gameId,studioId")] Connection connection)
        {
            if (id != connection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(connection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnectionExists(connection.Id))
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
            ViewData["gameId"] = new SelectList(_context.Games, "gameId", "Console", connection.gameId);
            ViewData["studioId"] = new SelectList(_context.Studios, "studioId", "Address", connection.studioId);
            return View(connection);
        }

        // GET: Connections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connection = await _context.Connections
                .Include(c => c.Game)
                .Include(c => c.Studio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (connection == null)
            {
                return NotFound();
            }

            return View(connection);
        }

        // POST: Connections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var connection = await _context.Connections.FindAsync(id);
            if (connection != null)
            {
                _context.Connections.Remove(connection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnectionExists(int id)
        {
            return _context.Connections.Any(e => e.Id == id);
        }
    }
}
