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
    public class PayScalesController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public PayScalesController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: PayScales
        public async Task<IActionResult> Index()
        {
            var ourEduAMSDbContext = _context.PayScales.Include(p => p.Designation);
            return View(await ourEduAMSDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexAP()
        {
            var ourEduAMSDbContext = _context.PayScales.Include(p => p.Designation);
            return View(await ourEduAMSDbContext.ToListAsync());
        }

        // GET: PayScales/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScales = await _context.PayScales
                .Include(p => p.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payScales == null)
            {
                return NotFound();
            }

            return View(payScales);
        }

        // GET: PayScales/Create
        public IActionResult Create()
        {
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Name");
            return View();
        }

        // POST: PayScales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DesignationId,Amount")] PayScales payScales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payScales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Name", payScales.DesignationId);
            return View(payScales);
        }

        // GET: PayScales/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScales = await _context.PayScales.FindAsync(id);
            if (payScales == null)
            {
                return NotFound();
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Name", payScales.DesignationId);
            return View(payScales);
        }

        // POST: PayScales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DesignationId,Amount")] PayScales payScales)
        {
            if (id != payScales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payScales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayScalesExists(payScales.Id))
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
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Name", payScales.DesignationId);
            return View(payScales);
        }

        // GET: PayScales/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScales = await _context.PayScales
                .Include(p => p.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payScales == null)
            {
                return NotFound();
            }

            return View(payScales);
        }

        // POST: PayScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var payScales = await _context.PayScales.FindAsync(id);
            _context.PayScales.Remove(payScales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayScalesExists(long id)
        {
            return _context.PayScales.Any(e => e.Id == id);
        }
    }
}
