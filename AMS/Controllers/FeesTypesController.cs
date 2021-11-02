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
    public class FeesTypesController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public FeesTypesController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: FeesTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeesTypes.ToListAsync());
        }

        // GET: FeesTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feesTypes = await _context.FeesTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feesTypes == null)
            {
                return NotFound();
            }

            return View(feesTypes);
        }

        // GET: FeesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeesTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Term")] FeesTypes feesTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feesTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feesTypes);
        }

        // GET: FeesTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feesTypes = await _context.FeesTypes.FindAsync(id);
            if (feesTypes == null)
            {
                return NotFound();
            }
            return View(feesTypes);
        }

        // POST: FeesTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Term")] FeesTypes feesTypes)
        {
            if (id != feesTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feesTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeesTypesExists(feesTypes.Id))
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
            return View(feesTypes);
        }

        // GET: FeesTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feesTypes = await _context.FeesTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feesTypes == null)
            {
                return NotFound();
            }

            return View(feesTypes);
        }

        // POST: FeesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var feesTypes = await _context.FeesTypes.FindAsync(id);
            _context.FeesTypes.Remove(feesTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeesTypesExists(long id)
        {
            return _context.FeesTypes.Any(e => e.Id == id);
        }
    }
}
