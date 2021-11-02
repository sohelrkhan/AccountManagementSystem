using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;

namespace AMS.Controllers
{
    public class ComGendersController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public ComGendersController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: ComGenders
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComGenders.ToListAsync());
        }

        // GET: ComGenders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comGenders = await _context.ComGenders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comGenders == null)
            {
                return NotFound();
            }

            return View(comGenders);
        }

        // GET: ComGenders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComGenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,DataType")] ComGenders comGenders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comGenders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comGenders);
        }

        // GET: ComGenders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comGenders = await _context.ComGenders.FindAsync(id);           
            if (comGenders == null)
            {
                return NotFound();
            }
            return View(comGenders);
        }

        // POST: ComGenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsActive,DataType")] ComGenders comGenders)
        {
            if (id != comGenders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comGenders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComGendersExists(comGenders.Id))
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
            return View(comGenders);
        }

        // GET: ComGenders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comGenders = await _context.ComGenders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comGenders == null)
            {
                return NotFound();
            }

            return View(comGenders);
        }

        // POST: ComGenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var comGenders = await _context.ComGenders.FindAsync(id);
            _context.ComGenders.Remove(comGenders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComGendersExists(long id)
        {
            return _context.ComGenders.Any(e => e.Id == id);
        }
    }
}
