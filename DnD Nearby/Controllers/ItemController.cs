using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Models;
using DnD_Nearby.Services;

namespace DnD_Nearby.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService itemService;

        public ItemController(ItemService iService)
        {
            this.itemService = iService;
        }

        public IActionResult DisplayItems()
        {
            return View(itemService.Get());
        }

        public IActionResult AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Mode = "";
                int pp = int.Parse(HttpContext.Request.Form["PlatinumCost"]); // Messy, but effective
                int gp = int.Parse(HttpContext.Request.Form["GoldCost"]);
                int ep = int.Parse(HttpContext.Request.Form["ElectrumCost"]);
                int sp = int.Parse(HttpContext.Request.Form["SilverCost"]);
                int cp = int.Parse(HttpContext.Request.Form["CopperCost"]);
                item.Cost = new Coins(pp, gp, ep, sp, cp);
                itemService.Create(item);
                return Redirect("DisplayItems");
            }

            return View("ItemForm", item);
        }

        public IActionResult EditItem(Item item)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Mode = "";
                int pp = int.Parse(HttpContext.Request.Form["PlatinumCost"]); // Messy, but effective
                int gp = int.Parse(HttpContext.Request.Form["GoldCost"]);
                int ep = int.Parse(HttpContext.Request.Form["ElectrumCost"]);
                int sp = int.Parse(HttpContext.Request.Form["SilverCost"]);
                int cp = int.Parse(HttpContext.Request.Form["CopperCost"]);
                item.Cost = new Coins(pp, gp, ep, sp, cp);
                itemService.Update(item.Id, item);
                return Redirect("DisplayItems");
            }

            return View("ItemForm", item);
        }

        public IActionResult AddItemForm()
        {
            ViewBag.Mode = "Add";
            return View("ItemForm");
        }

        public IActionResult EditItemForm()
        {
            ViewBag.Mode = "Edit";
            return View("ItemForm");
        }

        public IActionResult ItemForm()
        {
            return View();
        }
    }
}
