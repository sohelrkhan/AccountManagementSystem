using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly OurEduAMSDbContext _context;

        public UsersController(OurEduAMSDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (HttpContext.Session.Get("userName") != null)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            var user = _context.Login.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
            if (user != null)
            {
                string username = user.FirstName + user.LastName;
                
                HttpContext.Session.Get("userName");

                if (user.UserType.Equals("Registrar"))
                {

                    return RedirectToAction("RegistrarIndex", "Users", new { userName = username });
                }
                else if (user.UserType.Equals("Accountant"))
                {
                    return RedirectToAction("AccountantIndex", "Users", new { userName = username });
                }
                
                else
                {
                    return RedirectToAction("Login", "Users");

                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userName");
            return RedirectToAction("Login", "Login");

        }


        public IActionResult RegistrarIndex()
        {
            var totalStudent = _context.Students.Count();
            ViewBag.totalStudent = totalStudent;

            var totalStaff = _context.Staffs.Count();
            ViewBag.totalStaff = totalStaff;

            return View();
        }
  
        public IActionResult AccountantIndex()
        {
            var totalStudent = _context.Students.Count();
            ViewBag.totalStudent = totalStudent;

            var totalStaff = _context.Staffs.Count();
            ViewBag.totalStaff = totalStaff;

            //Income Part
            var stuPayment = _context.StudentPayments;
            var stuPaymentTotal = stuPayment.Select(s => s.PaidAmount).Sum();
            ViewBag.stuPaymentTotal = stuPaymentTotal;

            var donation = _context.Donation;
            var donationTotal = donation.Select(s => s.Amount).Sum();
            ViewBag.donationTotal = donationTotal;

            //var totalIncome = stuPaymentTotal + donationTotal;
            //ViewBag.totalIncome = totalIncome;

            //Expense Part
            var salary = _context.Salary;
            var salaryTotal = salary.Select(s => s.Amount).Sum();
            ViewBag.salaryTotal = salaryTotal;

            var expense = _context.Expenses;
            var expenseTotal = expense.Select(s => s.Amount).Sum();
            ViewBag.expenseTotal = expenseTotal;

            //var totalExpenses = salaryTotal + expenseTotal;
            //ViewBag.totalExpenses = totalExpenses;


            //var balance = totalIncome - totalExpenses;
            //ViewBag.balance = balance;

            return View();
        }

       
        
    }

}

