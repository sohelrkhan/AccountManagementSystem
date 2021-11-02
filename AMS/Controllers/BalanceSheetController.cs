using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AMS.Controllers
{
    public class BalanceSheetController : Controller
    {
        // GET: /<controller>/
        private readonly OurEduAMSDbContext _context;

        public BalanceSheetController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Income Part
            var stuPayment = _context.StudentPayments;
            var stuPaymentTotal = stuPayment.Select(s => s.PaidAmount).Sum();
            ViewBag.stuPaymentTotal = stuPaymentTotal;

            var donation = _context.Donation;
            var donationTotal = donation.Select(s => s.Amount).Sum();
            ViewBag.donationTotal = donationTotal;

            var totalIncome = stuPaymentTotal + donationTotal;
            ViewBag.totalIncome = totalIncome;
           
            //Expense Part
            var salary = _context.Salary;
            var salaryTotal = salary.Select(s => s.Amount).Sum();
            ViewBag.salaryTotal = salaryTotal;

            var expense = _context.Expenses;
            var expenseTotal = expense.Select(s => s.Amount).Sum();
            ViewBag.expenseTotal = expenseTotal;

            var totalExpenses = salaryTotal + expenseTotal;
            ViewBag.totalExpenses = totalExpenses;


            var balance = totalIncome - totalExpenses;
            ViewBag.balance = balance;

            return View();           
        }

    }
}
