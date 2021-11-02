using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using AMS.Models.ViewModels;

namespace AMS.Controllers
{
    public class FeesController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public FeesController(OurEduAMSDbContext context)
        {
            _context = context;
        }

       // GET: Fees
        public async Task<IActionResult> Index()
        {
            var ourEduAMSDbContext = _context.Fees.Include(f => f.Class).Include(f => f.FeesType);
            return View(await ourEduAMSDbContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(string selectedClass)
        //{
        //    // Use LINQ to get list of genres.
        //    IQueryable<long> feesQuery = from f in _context.Fees
        //        orderby f.ClassId
        //        select f.ClassId;

        //    var fees = from f in _context.Fees
        //        select f;

        //    if (!string.IsNullOrEmpty(selectedClass))
        //    {
        //        fees = fees.Where(f => f.ClassId == Convert.ToInt32(selectedClass));
        //    }

        //    var FeesViewModel = new FeesViewModel
        //    {
        //        SelectedClass = new SelectList(await feesQuery.Distinct().ToListAsync()),
        //        Fees = await Fees.ToListAsync()
        //    };

        //    return View(FeesViewModel);
        //}



        public async Task<IActionResult> IndexAP()
        {
            var ourEduAMSDbContext = _context.Fees.Include(f => f.Class).Include(f => f.FeesType);
            return View(await ourEduAMSDbContext.ToListAsync());
        }

        // GET: Fees/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees
                .Include(f => f.Class)
                .Include(f => f.FeesType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        public async Task<IActionResult> DetailsAP(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees
                .Include(f => f.Class)
                .Include(f => f.FeesType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // GET: Fees/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name");
            ViewData["FeesTypeId"] = new SelectList(_context.FeesTypes, "Id", "Name");
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassId,FeesTypeId,Name,Amount,DueDate")] Fees fees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name", fees.ClassId);
            ViewData["FeesTypeId"] = new SelectList(_context.FeesTypes, "Id", "Id", fees.FeesTypeId);
            return View(fees);
        }

        // GET: Fees/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees.FindAsync(id);
            if (fees == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name", fees.ClassId);
            ViewData["FeesTypeId"] = new SelectList(_context.FeesTypes, "Id", "Name", fees.FeesTypeId);
            return View(fees);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ClassId,FeesTypeId,Name,Amount,DueDate")] Fees fees)
        {
            if (id != fees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeesExists(fees.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name", fees.ClassId);
            ViewData["FeesTypeId"] = new SelectList(_context.FeesTypes, "Id", "Id", fees.FeesTypeId);
            return View(fees);
        }

        // GET: Fees/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees
                .Include(f => f.Class)
                .Include(f => f.FeesType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var fees = await _context.Fees.FindAsync(id);
            _context.Fees.Remove(fees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeesExists(long id)
        {
            return _context.Fees.Any(e => e.Id == id);
        }
    }
}
