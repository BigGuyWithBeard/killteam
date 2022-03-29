using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KillTeam.WebMVC.Data;
using KillTeam.WebMVC.Models;

namespace KillTeam.WebMVC.Controllers
{
    public class MinifiguresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MinifiguresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Minifigures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Minifigure.ToListAsync());
        }

        // GET: Minifigures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minifigure = await _context.Minifigure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minifigure == null)
            {
                return NotFound();
            }

            return View(minifigure);
        }

        // GET: Minifigures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Minifigures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rfid,Description,Image")] Minifigure minifigure)
        {
            if (ModelState.IsValid)
            {
                minifigure.Id = Guid.NewGuid();
                _context.Add(minifigure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(minifigure);
        }

        // GET: Minifigures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minifigure = await _context.Minifigure.FindAsync(id);
            if (minifigure == null)
            {
                return NotFound();
            }
            return View(minifigure);
        }

        // POST: Minifigures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Rfid,Description,Image")] Minifigure minifigure)
        {
            if (id != minifigure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minifigure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinifigureExists(minifigure.Id))
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
            return View(minifigure);
        }

        // GET: Minifigures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minifigure = await _context.Minifigure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minifigure == null)
            {
                return NotFound();
            }

            return View(minifigure);
        }

        // POST: Minifigures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var minifigure = await _context.Minifigure.FindAsync(id);
            _context.Minifigure.Remove(minifigure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinifigureExists(Guid id)
        {
            return _context.Minifigure.Any(e => e.Id == id);
        }
    }
}
