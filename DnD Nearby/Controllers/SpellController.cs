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

        Spell tmpSpell = new Spell
            (
                "Acid Splash", //name
                "Conjuration", //school
                "1 Action", //casting time
                "60 Feet", //range
                "Instantaneous", //duration
                new string[] { "V", "S" }, //components 
                new string[] { "Artificer", "Sorcerer", "Wizard" }, //acuired by
                "You hurl a bubble of acid. Choose one creature you can see within range, or choose two creatures you can see within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage." +
                " At Higher Levels.This spell’s damage increases by 1d6 when you reach 5th level(2d6), 11th level(3d6), and 17th level(4d6)."
            );
        List<Spell> tmpSpellList = new List<Spell>();

        public IActionResult SpellPage()
        {
            return View(tmpSpell);
        }
        [HttpPost]
        public IActionResult GetSpellPage(int Id)
        {
            var spell = tmpSpellList.Find(s => s.ID == Id);
            return View("SpellPage", spell);
        }
    }
}
