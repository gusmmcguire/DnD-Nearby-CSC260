using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DnD_Nearby.Models;
using DnD_Nearby.Enums;

namespace DnD_Nearby.Controllers
{
    public class EncounterController : Controller
    {
        Encounter encounter = new Encounter();
        Creature[] creatures =
        {
            new StatBlock(Enums.eCR.Two, "Goosenator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
            new StatBlock(Enums.eCR.Two, "Isaianator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
            new StatBlock(Enums.eCR.Two, "Carlonator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
            new StatBlock(Enums.eCR.Two, "Jarenator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
            new StatBlock(Enums.eCR.Two, "Petenator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
            new PlayerCharacter("Luciana", "half-gnome",new int[] { 1, 2, 3, 4, 5, 6 }, 1, 0, new List<string>() { "Common", "Gnomish" }, "Goose", "Sword-thingy", 10, "dead", new List<string>() { "urg" })
        };

        public EncounterController()
        {
            foreach (Creature creature in creatures)
            {
                encounter.AddCreature(creature);
            }
        }

        public IActionResult Encounter()
        {


            EncounterPage ep = new EncounterPage();
            ep.encounter = encounter;


            ViewBag.encounter = encounter;
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
    }
}
