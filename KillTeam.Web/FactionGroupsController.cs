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
    public class FactionGroupsController : Controller
    {
        private readonly KillTeamWebContext _context;

        public FactionGroupsController(KillTeamWebContext context)
        {
            _context = context;
        }

        // GET: FactionGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.FactionGroup.ToListAsync());
        }

        // GET: FactionGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factionGroup = await _context.FactionGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factionGroup == null)
            {
                return NotFound();
            }

            return View(factionGroup);
        }

        // GET: FactionGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FactionGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] FactionGroup factionGroup)
        {
            if (ModelState.IsValid)
            {
                factionGroup.Id = Guid.NewGuid();
                _context.Add(factionGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factionGroup);
        }

        // GET: FactionGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factionGroup = await _context.FactionGroup.FindAsync(id);
            if (factionGroup == null)
            {
                return NotFound();
            }
            return View(factionGroup);
        }

        // POST: FactionGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] FactionGroup factionGroup)
        {
            if (id != factionGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factionGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactionGroupExists(factionGroup.Id))
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
            return View(factionGroup);
        }

        // GET: FactionGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factionGroup = await _context.FactionGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factionGroup == null)
            {
                return NotFound();
            }

            return View(factionGroup);
        }

        // POST: FactionGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var factionGroup = await _context.FactionGroup.FindAsync(id);
            _context.FactionGroup.Remove(factionGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactionGroupExists(Guid id)
        {
            return _context.FactionGroup.Any(e => e.Id == id);
        }
    }
}
