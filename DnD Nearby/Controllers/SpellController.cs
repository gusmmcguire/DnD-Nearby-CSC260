using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Models;
using DnD_Nearby.Services;
using Microsoft.AspNetCore.Authorization;

namespace DnD_Nearby.Controllers
{
    [Authorize]
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

        public IActionResult SpellPage()
        {
            return View(spService.Get().OrderBy(s => s.spellLevel).ToList());
        }

        public IActionResult SearchSpells(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View("SpellPage", spService.Get().OrderBy(s => s.spellLevel).ToList());
            }
            List<Spell> matchingSpells = new List<Spell>();

            foreach(var spell in spService.Get().OrderBy(s => s.spellLevel).ToList())
            {
                if (spell.spellName.ToLower().Contains(searchTerm.ToLower()))
                {
                    matchingSpells.Add(spell);
                }
            }

            return View("SpellPage", matchingSpells);
        }
    }
}
