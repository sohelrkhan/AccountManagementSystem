using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMS.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace AMS.Controllers
{
    public class SalaryViewController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public SalaryViewController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> StaffList(string id)
        {
            var ourEduAMSDbContext = from s in _context.Staffs.Include(s => s.Class)
                                                              .Include(s => s.Designation)
                                                              .Include ( s => s.Bonus)
                                                              .Include(s => s.Designation.PayScales)
                                                              .Include(s => s.ExtraIncomes)
                                                              .Include(s => s.SalaryIncrements)
                                     select s;

            if (!String.IsNullOrEmpty(id))
            {
                ourEduAMSDbContext = ourEduAMSDbContext.Where(s => s.Id == Convert.ToInt32(id));
            }
            return View(await ourEduAMSDbContext.ToListAsync());
        }



        public IActionResult GenerateSalary2(string id, string month, string year)
        {

            var ourEduAMSDbContext = from s in _context.Staffs.Include(s => s.Class)
                    .Include(s => s.Designation)

                    .Include(s => s.Designation.PayScales)
                    .Include(s => s.SalaryIncrements)

                    .Include(s => s.Bonus)
                    .Include(s => s.ExtraIncomes)

                select s;

            ViewBag.month = month;
            ViewBag.year = year;

            ourEduAMSDbContext = ourEduAMSDbContext.Where(s => s.Id == Convert.ToInt32(id));
                
            return View(ourEduAMSDbContext.FirstOrDefault());
        }
    }
}
