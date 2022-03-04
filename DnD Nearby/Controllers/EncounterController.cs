using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Services;
using DnD_Nearby.Models;
using DnD_Nearby.Enums;

namespace DnD_Nearby.Controllers
{
    public class EncounterController : Controller
    {
        private readonly AccountService accService;
        private readonly EncounterService enService;
        private readonly StatBlockService sbService;
        private readonly PartialPlayerService ppcService;

        public EncounterController(AccountService accIn, EncounterService enIn, StatBlockService sbIn, PartialPlayerService ppcIn)
        {
            accService = accIn;
            enService = enIn;
            sbService = sbIn;
            ppcService = ppcIn;
        }

        public IActionResult Index()
        {
            return Redirect("/Home/Index");
        }

        public IActionResult EncounterCreation(string user = "admin_test")
        {

            EncounterCreationPage ecp = new EncounterCreationPage();
            //EncounterCreationPage ecp = new EncounterCreationPage(sbService.GetStatBlocksByAccount(accService.GetAccountByName(user).Id));
            ecp.setupString(sbService, ppcService);
            return View(ecp);
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

        public IActionResult CreateEncounter(EncounterCreationPage enP)
        {
            if (ModelState.IsValid)
            {
                var en = enP.encounter;
                en.CreatureID = enP.CreatureIDs.ToList();
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

        public IActionResult AddStatToEncounter(List<string> creatures, string stat)
        {
            creatures.Add(stat);
            EncounterCreationPage creationPage = new EncounterCreationPage(sbService.Get());
            creationPage.CreatureIDs = creatures.ToArray();
            creationPage.setupString(sbService, ppcService);
            return View("EncounterCreation", creationPage);
        }

        public IActionResult Encounter()
        {
            EncounterPage ep = new EncounterPage();
            ep.encounter.setupCreatures(sbService, ppcService);
            return View(ep);
        }

        [HttpPost]
        public IActionResult CalcDiff(EncounterPage ep)
        {
            foreach(StatBlock sb in ep.StatBlocks)
            {
                ep.encounter.AddCreature(sb);
            }
            foreach(PlayerCharacter pc in ep.PlayerCharacters)
            {
                ep.encounter.AddCreature(pc);
            }
            ep.diff = ep.encounter.CalcDifficulty();

            return View("Encounter", ep);
        }

        [HttpPost]
        public IActionResult AddPlayerToEncounter(PlayerPartialMakerPage playerPartialPage)
        {

            ppcService.Create(playerPartialPage.pcForPage);
            playerPartialPage.CreatureRef.Add(playerPartialPage.pcForPage.Id);
            EncounterCreationPage creationPage = new EncounterCreationPage(sbService.Get());
            creationPage.CreatureIDs = playerPartialPage.CreatureRef.ToArray();
            creationPage.setupString(sbService, ppcService);
            return View("EncounterCreation", creationPage);

        }
    }
}
 