using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KillTeam.WebApp.Data;
using KillTeam.WebApp.Models;

namespace KillTeam.WebApp.Controllers
{
    public class MinifigureController : Controller
    {
        private readonly KillTeamWebAppContext _context;

        public MinifigureController(KillTeamWebAppContext context)
        {
            _context = context;
        }

        // GET: Minifigure
        public async Task<IActionResult> Index()
        {
            return View(await _context.MinifigureModel.ToListAsync());
        }

        // GET: Minifigure/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minifigureModel = await _context.MinifigureModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minifigureModel == null)
            {
                return NotFound();
            }

            return View(minifigureModel);
        }

        // GET: Minifigure/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Minifigure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RfidKey,Name,Description,Image")] MinifigureModel minifigureModel)
        {
            if (ModelState.IsValid)
            {
                minifigureModel.Id = Guid.NewGuid();
                _context.Add(minifigureModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(minifigureModel);
        }

        // GET: Minifigure/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minifigureModel = await _context.MinifigureModel.FindAsync(id);
            if (minifigureModel == null)
            {
                return NotFound();
            }
            return View(minifigureModel);
        }

        // POST: Minifigure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RfidKey,Name,Description,Image")] MinifigureModel minifigureModel)
        {
            if (id != minifigureModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minifigureModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinifigureModelExists(minifigureModel.Id))
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
            return View(minifigureModel);
        }

        // GET: Minifigure/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minifigureModel = await _context.MinifigureModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minifigureModel == null)
            {
                return NotFound();
            }

            return View(minifigureModel);
        }

        // POST: Minifigure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var minifigureModel = await _context.MinifigureModel.FindAsync(id);
            _context.MinifigureModel.Remove(minifigureModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinifigureModelExists(Guid id)
        {
            return _context.MinifigureModel.Any(e => e.Id == id);
        }
    }
}
