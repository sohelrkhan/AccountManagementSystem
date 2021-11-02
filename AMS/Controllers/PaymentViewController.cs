using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Models;
using AMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AMS.Controllers
{
    public class PaymentViewController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public PaymentViewController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> StudentList(string id)
        {
            var ourEduAMSDbContext =from s in  _context.Students
                                    .Include(s => s.Class)
                                    .Include(s => s.Gender)
                                    .Include(s =>s.Scholarships)
                                    select s;

            if (!String.IsNullOrEmpty(id))
            {
                ourEduAMSDbContext = ourEduAMSDbContext.Where(s => s.Id == Convert.ToInt32(id));
            }
            return View(await ourEduAMSDbContext.ToListAsync());
        }

        //Fees List
        public async Task<IActionResult> FeesList(long id, long classId)
        {
            if (id == null)
            {
                //
            }
            
            List<Fees> fees = _context.Fees.ToList();
            List<StudentPayments> studentPayments = _context.StudentPayments.ToList();

            var FeesListView = from f in fees.Where(f =>f.ClassId == classId)
                          join sp in studentPayments on f.Id equals sp.FeeId into table1
                          from sp in table1.DefaultIfEmpty()
                          orderby f.DueDate                       

                          select new FeesViewModel
                          {
                             
                              fees = f,
                              studentPayments = sp,                              
                          };

            //Total Fees Amount
            var totalFeesAmount = _context.Fees.Where(f => f.ClassId == classId).Select(f => f.Amount).Sum();
            ViewBag.totalFeesAmount = totalFeesAmount;

            //Total Fine
            var fine = _context.StudentPayments.Where(s => s.StudentId == id).Select(s => s.Fine).Sum();
            ViewBag.fine = fine;

            //Total Discount
            var Discount = _context.StudentPayments.Where(s => s.StudentId == id).Select(s => s.Discount).Sum();
            ViewBag.Discount = Discount;

            //Total Paid Amount
            var paidAmount = _context.StudentPayments.Where(s => s.StudentId == id).Select(s => s.PaidAmount).Sum();
            ViewBag.paidAmount = paidAmount;

            

            var stud = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.studentId = stud.Id;
            ViewBag.StudentName = stud.FirstName + " " + stud.LastName;
            ViewBag.StudentClass = stud.ClassId;
            ViewBag.StudentDOB = stud.Dob;
            ViewBag.StudentAdmitedYear = stud.AdmittedYear;

            var className = _context.Classes.Where(s => s.Id == classId).Select(s => s.Name).FirstOrDefault();
            ViewBag.className = className;

            var StudentScholarship = _context.Scholarships.Where(s => s.StudentId == id)
                .Select(s =>s.Percentage).FirstOrDefault();
            ViewBag.StudentScholarship = StudentScholarship;           

            
            //Total Tution Fees
            int totalTutionFess = 500 * 12;
            ViewBag.totalTutionFess = totalTutionFess;

            //0.5 Percent Calculate
            var percent = ((decimal)StudentScholarship  / 100) ;

            //Get Scholarship
            var GetScholarship = totalTutionFess * percent;
            ViewBag.GetScholarship = GetScholarship;


            //Need To pay
            var NeedToPay = totalFeesAmount - GetScholarship;
            ViewBag.NeedToPay = NeedToPay;

            //Dues
            var due = NeedToPay - paidAmount;
            ViewBag.due = due;

            return View(FeesListView);
        }

        public async Task<IActionResult> StudentFeesReport()
        {
            //var stud = _context.StudentPayments.Include(s => s.Fee);
            //var studentPayment = _context.Students.Include(s => s.StudentPayments);

            //var StuPayList = studentPayment.ToList();
            //var totalStudent = _context.Students.Count();
            //ViewBag.totalStudent= totalStudent;
            //var totalPaid = StuPayList.Select(s => s.StudentPayments.Amount);
            //var total = StuPayList.Select(s => s.StudentPayments).Sum();
            //var paid = StuPayList.Select(s => s.PaidAmount).Sum();


            //var due = total - paid;

            //ViewBag.Total = total;
            //ViewBag.Paid = paid;
            //ViewBag.Due = due;

            return View();
        }
    }
}
