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
    public class SalaryIncrementsController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public SalaryIncrementsController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: SalaryIncrements
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalaryIncrements.ToListAsync());
        }

        // GET: SalaryIncrements/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryIncrements = await _context.SalaryIncrements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryIncrements == null)
            {
                return NotFound();
            }

            return View(salaryIncrements);
        }

        // GET: SalaryIncrements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalaryIncrements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffId,Date,Amount")] SalaryIncrements salaryIncrements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryIncrements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaryIncrements);
        }

        // GET: SalaryIncrements/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryIncrements = await _context.SalaryIncrements.FindAsync(id);
            if (salaryIncrements == null)
            {
                return NotFound();
            }
            return View(salaryIncrements);
        }

        // POST: SalaryIncrements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,StaffId,Date,Amount")] SalaryIncrements salaryIncrements)
        {
            if (id != salaryIncrements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryIncrements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryIncrementsExists(salaryIncrements.Id))
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
            return View(salaryIncrements);
        }

        // GET: SalaryIncrements/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryIncrements = await _context.SalaryIncrements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaryIncrements == null)
            {
                return NotFound();
            }

            return View(salaryIncrements);
        }

        // POST: SalaryIncrements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var salaryIncrements = await _context.SalaryIncrements.FindAsync(id);
            _context.SalaryIncrements.Remove(salaryIncrements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryIncrementsExists(long id)
        {
            return _context.SalaryIncrements.Any(e => e.Id == id);
        }
    }
}
