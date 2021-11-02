using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;

namespace AMS.Controllers
{
    public class DesignationsController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public DesignationsController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: Designations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Designations.ToListAsync());
        }

        // GET: Designations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designations = await _context.Designations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designations == null)
            {
                return NotFound();
            }

            return View(designations);
        }

        // GET: Designations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Designations designations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(designations);
        }

        // GET: Designations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designations = await _context.Designations.FindAsync(id);
            if (designations == null)
            {
                return NotFound();
            }
            return View(designations);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] Designations designations)
        {
            if (id != designations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationsExists(designations.Id))
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
            return View(designations);
        }

        // GET: Designations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designations = await _context.Designations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designations == null)
            {
                return NotFound();
            }

            return View(designations);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var designations = await _context.Designations.FindAsync(id);
            _context.Designations.Remove(designations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationsExists(long id)
        {
            return _context.Designations.Any(e => e.Id == id);
        }
    }
}
