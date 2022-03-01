using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Models;
using DnD_Nearby.Services;

namespace DnD_Nearby.Controllers
{
    public class StatBlockController : Controller
    {
        private readonly AccountService accService;
        private readonly StatBlockService statService;

        public StatBlockController(StatBlockService sbS, AccountService aS)
        {
            statService = sbS;
            accService = aS;
        }

        

        public IActionResult Index()
        {
            return Redirect("/Home/Index");
        }

        public IActionResult StatBlockCreation()
        {
            return View();
        }
        public IActionResult StatBlockCollectionForm()
        {
            return View("StatBlockCollection");
        }

        public IActionResult StatBlockCollection(string user)
        {
            List<StatBlock> tempList = statService.Get().Where(statBlock => statBlock.accountId == accService.GetAccountByName(user).Id).ToList();

            return View(tempList);
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
                //when it comes in here, we will be expecting a username in accId, then updating that
                stat.accountId = accService.GetAccountByName(stat.accountId).Id;
                statService.Create(stat);
                return Index();
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
