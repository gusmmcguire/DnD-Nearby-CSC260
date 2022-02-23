using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DnD_Nearby.Models;

namespace DnD_Nearby.Controllers
{
    public class EncounterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Encounter()
        {
            Encounter encounter = new Encounter();
            Creature[] creatures =
            {
                new StatBlock(Enums.eCR.Twenty, "Goosenator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
                new StatBlock(Enums.eCR.Twenty, "Isaianator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
                new StatBlock(Enums.eCR.Twenty, "Carlonator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
                new StatBlock(Enums.eCR.Twenty, "Jarenator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" }),
                new StatBlock(Enums.eCR.Twenty, "Petenator", "Sweater", new int[] { 20, 20, 20, 20, 20, 20}, 10000, 35, new List<string>() { "Common" })
            };

            foreach (Creature creature in creatures)
            {
                encounter.AddCreature(creature);
            }

            return View(encounter);
        }
    }
}
