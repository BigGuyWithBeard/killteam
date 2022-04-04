using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KillTeam.WebRazor.Models;

namespace KillTeam.WebRazor
{
    public class GovernmentModelsController : Controller
    {
        private readonly KillTeamDbContext _context;

        public GovernmentModelsController(KillTeamDbContext context)
        {
            _context = context;
        }

        // GET: GovernmentModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GovernmentModel.ToListAsync());
        }

        // GET: GovernmentModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentModel = await _context.GovernmentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (governmentModel == null)
            {
                return NotFound();
            }

            return View(governmentModel);
        }

        // GET: GovernmentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GovernmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] GovernmentModel governmentModel)
        {
            if (ModelState.IsValid)
            {
                governmentModel.Id = Guid.NewGuid();
                _context.Add(governmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(governmentModel);
        }

        // GET: GovernmentModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentModel = await _context.GovernmentModel.FindAsync(id);
            if (governmentModel == null)
            {
                return NotFound();
            }
            return View(governmentModel);
        }

        // POST: GovernmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] GovernmentModel governmentModel)
        {
            if (id != governmentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(governmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GovernmentModelExists(governmentModel.Id))
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
            return View(governmentModel);
        }

        // GET: GovernmentModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentModel = await _context.GovernmentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (governmentModel == null)
            {
                return NotFound();
            }

            return View(governmentModel);
        }

        // POST: GovernmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var governmentModel = await _context.GovernmentModel.FindAsync(id);
            _context.GovernmentModel.Remove(governmentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GovernmentModelExists(Guid id)
        {
            return _context.GovernmentModel.Any(e => e.Id == id);
        }
    }
}
