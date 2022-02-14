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

        public IActionResult CreateAccount(Account acc)
        {
            if (ModelState.IsValid)
            {
                accService.Create(acc);
            }
            return View("AccountCreation");
        }
    }
}
