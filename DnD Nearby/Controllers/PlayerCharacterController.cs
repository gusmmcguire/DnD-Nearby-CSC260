using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Services;
using DnD_Nearby.Models;

namespace DnD_Nearby.Controllers
{
    public class PlayerCharacterController : Controller
    {
        private readonly AccountService accService;
        private readonly PlayerCharacterService chService;

        public PlayerCharacterController(PlayerCharacterService cS, AccountService aS)
        {
            chService = cS;
            accService = aS;
        }

        public IActionResult Index()
        {
            return Redirect("/Home/Index");
        }

        public IActionResult CharacterCreation()
        {
            return View();
        }
        public IActionResult CharacterCollectionForm()
        {
            return View("CharacterCollection");
        }

        public IActionResult CharacterCollection(string user)
        {
            List<PlayerCharacter> tempList = chService.Get().Where(character => character.accountId == accService.GetAccountByName(user).Id).ToList();

            return View(tempList);
        }

        public IActionResult CharacterEditor()
        {
            return View();
        }

        public IActionResult SingleCharacter(PlayerCharacter ch)
        {
            return View(ch);
        }

        public IActionResult CreateCharacter(PlayerCharacter ch)
        {
            if (ModelState.IsValid)
            {
                //when it comes in here, we will be expecting a username in accId, then updating that
                ch.accountId = accService.GetAccountByName(ch.accountId).Id;
                chService.Create(ch);
                return Index();
            }
            ViewBag.warning = "something not valid";
            return View("CharacterCreation");
        }

        public IActionResult UpdateCharacter(PlayerCharacter ch)
        {
            if(chService.GetPlayerCharacter(ch.Id) == null)
            {
                ViewBag.warning = "Trying to edit a non existant character";
                return View("CharacterEditor");
            }
            if (ModelState.IsValid)
            {
                chService.Update(ch.Id, ch);
                return SingleCharacter(ch);
            }
            ViewBag.warning = "Invalid model";
            return View("CharacterEditor");
        }
    }
}
