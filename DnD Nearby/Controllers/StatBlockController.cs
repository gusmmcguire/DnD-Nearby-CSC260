using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Models;
using DnD_Nearby.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DnD_Nearby.Controllers
{
    [Authorize]
    public class StatBlockController : Controller
    {
        private readonly AccountService accService;
        private readonly StatBlockService statService;

        public StatBlockController(StatBlockService sbS, AccountService aS)
        {
            statService = sbS;
            accService = aS;
        }

        public IActionResult StatBlockCreation()
        {
            return View();
        }

        public IActionResult StatBlockCollection()
        {
            return View(statService.Get().Where(stat => stat.accountId.ToString() == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList());
        }

        public IActionResult StatBlockEditor()
        {
            return View();
        }

        public IActionResult SingleStatBlock(StatBlock stat)
        {
            return View(stat);
        }

        public IActionResult CreateStatBlock(StatBlock stat)
        {
            if (ModelState.IsValid)
            {
                stat.accountId = accService.GetAccount(stat.accountId.ToString().ToUpper()).Id;
                statService.Create(stat);
                return View("StatBlockCollection", statService.Get().Where(stat => stat.accountId.ToString() == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList());
            }
            ViewBag.warning = "something not valid";
            return View("StatBlockCreation");
        }

        public IActionResult UpdateStatBlock(StatBlock stat)
        {
            if (statService.GetStatBlock(stat.Id) == null)
            {
                ViewBag.warning = "Trying to edit a non existant stat block";
                return View("StatBlockEditor");
            }
            if (ModelState.IsValid)
            {
                statService.Update(stat.Id, stat);
                return SingleStatBlock(stat);
            }
            ViewBag.warning = "Invalid model";
            return View("StatBlockEditor");
        }
    }
}
