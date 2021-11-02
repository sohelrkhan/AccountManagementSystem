using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;

using Rotativa;

namespace AMS.Controllers
{
    public class StudentsController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public StudentsController(OurEduAMSDbContext context)
        {
            _context = context;
        }

   

        public async Task<IActionResult> Index(string id)
        {
            var students = from s in _context.Students.Include(s => s.Class)
                                                      .Include(s => s.Gender)
                           select s;
            if (!String.IsNullOrEmpty(id))
            {
                students = students.Where(s => s.Id == Convert.ToInt32(id));
            }

            return View(await students.ToListAsync());
        }



        //public  ActionResult PrintAllStudent()
        //{
        //    var q = new Rotativa.ActionAsPdf("Index");
        //    return  q;
        //}

        //public ActionResult PrintAllEmployee()
        //{
        //    var report = new Rotativa.ActionAsPdf("Employees");
        //    return report;
        //}
        //[~Sohel-23/12/2019]

        public async Task<IActionResult> IndexAP(string id)
        {
            var students = from s in _context.Students.Include(s => s.Class)
                    .Include(s => s.Gender)
                select s;
            if (!String.IsNullOrEmpty(id))
            {
                students = students.Where(s => s.Id == Convert.ToInt32(id));
            }

            return View(await students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.ComGenders, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassId,GenderId,FirstName,LastName,AdmittedYear,PresentAddress,PermanentAddress,Dob")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name", students.ClassId);
            ViewData["GenderId"] = new SelectList(_context.ComGenders, "Id", "Name", students.GenderId);
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name", students.ClassId);
            ViewData["GenderId"] = new SelectList(_context.ComGenders, "Id", "Name", students.GenderId);
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ClassId,GenderId,FirstName,LastName,AdmittedYear,PresentAddress,PermanentAddress,Dob")] Students students)
        {
            if (id != students.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Name", students.ClassId);
            ViewData["GenderId"] = new SelectList(_context.ComGenders, "Id", "Name", students.GenderId);
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var students = await _context.Students.FindAsync(id);
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(long id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
