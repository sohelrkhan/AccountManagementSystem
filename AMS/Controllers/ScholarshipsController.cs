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
    public class ScholarshipsController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public ScholarshipsController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: Scholarships
        public async Task<IActionResult> Index()
        {
            var ourEduAMSDbContext = _context.Scholarships.Include(s => s.Student);
            return View(await ourEduAMSDbContext.ToListAsync());         
        }

        public async Task<IActionResult> IndexAP()
        {
            var ourEduAMSDbContext = _context.Scholarships.Include(s => s.Student);
            return View(await ourEduAMSDbContext.ToListAsync());
        }

        // GET: Scholarships/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scholarships = await _context.Scholarships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scholarships == null)
            {
                return NotFound();
            }

            return View(scholarships);
        }

        // GET: Scholarships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scholarships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,Percentage")] Scholarships scholarships)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scholarships);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scholarships);
        }

        // GET: Scholarships/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scholarships = await _context.Scholarships.FindAsync(id);
            if (scholarships == null)
            {
                return NotFound();
            }
            return View(scholarships);
        }

        // POST: Scholarships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,StudentId,Percentage")] Scholarships scholarships)
        {
            if (id != scholarships.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scholarships);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScholarshipsExists(scholarships.Id))
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
            return View(scholarships);
        }

        // GET: Scholarships/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scholarships = await _context.Scholarships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scholarships == null)
            {
                return NotFound();
            }

            return View(scholarships);
        }

        // POST: Scholarships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var scholarships = await _context.Scholarships.FindAsync(id);
            _context.Scholarships.Remove(scholarships);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScholarshipsExists(long id)
        {
            return _context.Scholarships.Any(e => e.Id == id);
        }
    }
}
