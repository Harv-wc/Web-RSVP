using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_7D.Models;

namespace Lab_7D.Controllers
{
    public class HomeController : Controller
    {
        Repository _dbContext = new Repository();
        public ViewResult Index()
        {
            _dbContext.Database.EnsureCreated();
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _dbContext.GuestResponses.Add(guestResponse);
                _dbContext.SaveChanges();
                return View("Thanks", guestResponse);
            } else
            {
                // there is a validation error
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(_dbContext.GuestResponses.Where(r => r.WillAttend == true));
        }
    }
}
