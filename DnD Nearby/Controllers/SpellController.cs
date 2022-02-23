using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Models;
using DnD_Nearby.Services;

namespace DnD_Nearby.Controllers
{
    public class SpellController : Controller
    {
        private readonly SpellService spService;

        public SpellController(SpellService spS)
        {
            spService = spS;
        }

        public IActionResult Index()
        {
            return Redirect("/Home/Index");
        }

        public IActionResult SpellAddDatabase()
        {
            return View();
        }
        
        public IActionResult CreateSpell(Spell spell)
        {
            spService.Create(spell);
            return View("SpellAddDatabase");
        }

        public IActionResult UpdateSpell(Spell spell)
        {
            spService.Update(spell.Id, spell);
            return SpellAddDatabase();
        }
    }
}
