using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Services;
using DnD_Nearby.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DnD_Nearby.Controllers
{
    [Authorize]
    public class PlayerCharacterController : Controller
    {
        private readonly AccountService accService;
        private readonly PlayerCharacterService chService;

        public PlayerCharacterController(PlayerCharacterService cS, AccountService aS)
        {
            chService = cS;
            accService = aS;
        }

        public IActionResult CharacterCreation()
        {
            return View();
        }
        public IActionResult CharacterCollection()
        {
            List<PlayerCharacter> tempList = chService.Get().Where(character => character.accountId == accService.GetAccount(User.FindFirst(ClaimTypes.NameIdentifier).Value).Id).ToList();

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
                //ch.accountId = accService.GetAccountByName(ch.accountId).Id;
                chService.Create(ch);
                return View("CharacterCollection", chService.Get().Where(character => character.accountId == accService.GetAccount(User.FindFirst(ClaimTypes.NameIdentifier).Value).Id).ToList());
            }
            ViewBag.warning = "something not valid";
            return View("CharacterCreation");
        }

        public IActionResult UpdateCharacter(PlayerCharacter ch)
        {
            if(chService.GetPlayerCharacter(ch.Id) == null)
            {
                ViewBag.warning = "Trying to edit a non existant character";
                return View("CharacterCollection");
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
