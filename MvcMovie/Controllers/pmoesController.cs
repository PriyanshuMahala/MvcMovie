using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class pmoesController : Controller
    {
        private readonly MvcMovieContext _context;

        public pmoesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: pmoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.pmo.ToListAsync());
        }

        // GET: pmoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmo = await _context.pmo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pmo == null)
            {
                return NotFound();
            }

            return View(pmo);
        }

        // GET: pmoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pmoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] pmo pmo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pmo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pmo);
        }

        // GET: pmoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmo = await _context.pmo.FindAsync(id);
            if (pmo == null)
            {
                return NotFound();
            }
            return View(pmo);
        }

        // POST: pmoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] pmo pmo)
        {
            if (id != pmo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pmo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pmoExists(pmo.Id))
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
            return View(pmo);
        }

        // GET: pmoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmo = await _context.pmo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pmo == null)
            {
                return NotFound();
            }

            return View(pmo);
        }

        // POST: pmoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pmo = await _context.pmo.FindAsync(id);
            if (pmo != null)
            {
                _context.pmo.Remove(pmo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool pmoExists(int id)
        {
            return _context.pmo.Any(e => e.Id == id);
        }
    }
}
