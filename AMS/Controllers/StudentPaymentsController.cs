using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using Rotativa.AspNetCore;

namespace AMS.Controllers
{
    public class StudentPaymentsController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public StudentPaymentsController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        // GET: StudentPayments
        public async Task<IActionResult> Index()
        {
            var stuPayment = _context.StudentPayments;
            var stuPaymentTotal = stuPayment.Select(s => s.PaidAmount).Sum();
            ViewBag.stuPaymentTotal = stuPaymentTotal;

            var ourEduAMSDbContext = _context.StudentPayments.Include(s => s.Fee).Include(s => s.PaymentType);
            return View(await ourEduAMSDbContext.ToListAsync());
        }

        public IActionResult PrintById(long id)
        {
            var model = _context.StudentPayments.Include(s => s.Fee)
                    .Include(s => s.PaymentType)
                    .FirstOrDefault(x => x.Id == id)
                ;

                return new ViewAsPdf("PrintById", model);
        }

        // GET: StudentPayments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayments = await _context.StudentPayments
                .Include(s => s.Fee)
                .Include(s => s.PaymentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentPayments == null)
            {
                return NotFound();
            }

            return View(studentPayments);
        }

        // GET: StudentPayments/Create
        public IActionResult Create()
        {
            ViewData["FeeId"] = new SelectList(_context.Fees, "Id", "Name");
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Name");
            return View();
        }

        // POST: StudentPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaymentDate,StudentId,FeeId,PaymentTypeId,Fine,Discount,PaidAmount,Remarks")] StudentPayments studentPayments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentPayments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeeId"] = new SelectList(_context.Fees, "Id", "Id", studentPayments.FeeId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Id", studentPayments.PaymentTypeId);
            return View(studentPayments);
        }

        // GET: StudentPayments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayments = await _context.StudentPayments.FindAsync(id);
            if (studentPayments == null)
            {
                return NotFound();
            }
            ViewData["FeeId"] = new SelectList(_context.Fees, "Id", "Name", studentPayments.FeeId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Name", studentPayments.PaymentTypeId);
            return View(studentPayments);
        }

        // POST: StudentPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PaymentDate,StudentId,FeeId,PaymentTypeId,Fine,Discount,PaidAmount,Remarks")] StudentPayments studentPayments)
        {
            if (id != studentPayments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentPayments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPaymentsExists(studentPayments.Id))
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
            ViewData["FeeId"] = new SelectList(_context.Fees, "Id", "Id", studentPayments.FeeId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Id", studentPayments.PaymentTypeId);
            return View(studentPayments);
        }

        // GET: StudentPayments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayments = await _context.StudentPayments
                .Include(s => s.Fee)
                .Include(s => s.PaymentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentPayments == null)
            {
                return NotFound();
            }

            return View(studentPayments);
        }

        // POST: StudentPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var studentPayments = await _context.StudentPayments.FindAsync(id);
            _context.StudentPayments.Remove(studentPayments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPaymentsExists(long id)
        {
            return _context.StudentPayments.Any(e => e.Id == id);
        }
    }
}
