using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Services;
using DnD_Nearby.Models;

namespace DnD_Nearby.Controllers
{
    public class EncounterController : Controller
    {
        private readonly AccountService accService;
        private readonly EncounterService enService;

        public EncounterController(AccountService accIn, EncounterService enIn)
        {
            accService = accIn;
            enService = enIn;
        }

        public IActionResult Index()
        {
            return Redirect("/Home/Index");
        }

        public IActionResult EncounterCreation()
        {
            return View();
        }

        public IActionResult EncounterCollectionForm()
        {
            return View("EncounterCollection");
        }

        public IActionResult EncounterCollection(string user)
        {
            List<Encounter> tempList = enService.Get().Where(encounter => encounter.accountId == accService.GetAccountByName(user).Id).ToList();
            return View(tempList);
        }

        public IActionResult EncounterEditor()
        {
            return View();
        }

        public IActionResult SingleEncounter(Encounter en)
        {
            return View(en);
        }

        public IActionResult CreateEncounter(Encounter en)
        {
            if (ModelState.IsValid)
            {
                en.accountId = accService.GetAccountByName(en.accountId).Id;
                enService.Create(en);
                return Index();
            }
            ViewBag.warning = "something not valid";
            return View("EncounterCreation");
        }

        public IActionResult UpdateEncounter(Encounter en)
        {
            if(enService.GetEncounter(en.ID) == null)
            {
                ViewBag.warning = "Trying to edit a non existant encounter";
                return View("EncounterCollection");
            }
            if (ModelState.IsValid)
            {
                enService.Update(en.ID, en);
                return SingleEncounter(en);
            }
            ViewBag.warning = "something invalid";
            return View("EncounterEditor");
        }
    }
}
