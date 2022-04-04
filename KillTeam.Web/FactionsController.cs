using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KillTeam.Web.Data;
using KillTeam.Web.Models;

namespace KillTeam.Web
{
    public class FactionsController : Controller
    {
        private readonly KillTeamWebContext _context;

        public FactionsController(KillTeamWebContext context)
        {
            _context = context;
        }

        // GET: Factions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Faction.ToListAsync());
        }

        // GET: Factions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faction = await _context.Faction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faction == null)
            {
                return NotFound();
            }

            return View(faction);
        }

        // GET: Factions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Factions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title")] Faction faction)
        {
            if (ModelState.IsValid)
            {
                faction.Id = Guid.NewGuid();
                _context.Add(faction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faction);
        }

        // GET: Factions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faction = await _context.Faction.FindAsync(id);
            if (faction == null)
            {
                return NotFound();
            }
            return View(faction);
        }

        // POST: Factions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Title")] Faction faction)
        {
            if (id != faction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactionExists(faction.Id))
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
            return View(faction);
        }

        // GET: Factions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faction = await _context.Faction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faction == null)
            {
                return NotFound();
            }

            return View(faction);
        }

        // POST: Factions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var faction = await _context.Faction.FindAsync(id);
            _context.Faction.Remove(faction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactionExists(Guid id)
        {
            return _context.Faction.Any(e => e.Id == id);
        }
    }
}
