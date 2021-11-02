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
    public class ExtraIncomesController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public ExtraIncomesController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: ExtraIncomes
        public async Task<IActionResult> Index()
        {
            var extraIncome = _context.ExtraIncomes;
            var extraIncomeTotal = extraIncome.Select(s => s.Amount).Sum();
            ViewBag.extraIncomeTotal = extraIncomeTotal;

            return View(await _context.ExtraIncomes.ToListAsync());
        }

        // GET: ExtraIncomes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraIncomes = await _context.ExtraIncomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extraIncomes == null)
            {
                return NotFound();
            }

            return View(extraIncomes);
        }

        // GET: ExtraIncomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExtraIncomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffId,Name,Amount,Date")] ExtraIncomes extraIncomes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extraIncomes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(extraIncomes);
        }

        // GET: ExtraIncomes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraIncomes = await _context.ExtraIncomes.FindAsync(id);
            if (extraIncomes == null)
            {
                return NotFound();
            }
            return View(extraIncomes);
        }

        // POST: ExtraIncomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,StaffId,Name,Amount,Date")] ExtraIncomes extraIncomes)
        {
            if (id != extraIncomes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extraIncomes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtraIncomesExists(extraIncomes.Id))
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
            return View(extraIncomes);
        }

        // GET: ExtraIncomes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraIncomes = await _context.ExtraIncomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extraIncomes == null)
            {
                return NotFound();
            }

            return View(extraIncomes);
        }

        // POST: ExtraIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var extraIncomes = await _context.ExtraIncomes.FindAsync(id);
            _context.ExtraIncomes.Remove(extraIncomes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtraIncomesExists(long id)
        {
            return _context.ExtraIncomes.Any(e => e.Id == id);
        }
    }
}
