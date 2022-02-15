using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Services;
using DnD_Nearby.Models;

namespace DnD_Nearby.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accService;

        public AccountController(AccountService aS)
        {
            accService = aS;
        }

        public IActionResult Index()
        {
            return Redirect("/Home/Index");
        }

        public IActionResult AccountCreation()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CreateAccount(Account acc)
        {
            if (accService.GetAccount(acc) != null)
            {
                ViewBag.Warning = "account already exists";
                return View("AccountCreation");
            }
            if (ModelState.IsValid)
            {
                accService.Create(acc);
                return Redirect("/Home/Index");
            }
            return View("AccountCreation");
        }

        //change to be better later
        public IActionResult LoginAction(Account acc)
        {
            if (accService.GetAccount(acc) != null)
            {
                return Content(accService.GetAccount(acc).FullName);
            }
            return View("Login");
        }
    }
}
