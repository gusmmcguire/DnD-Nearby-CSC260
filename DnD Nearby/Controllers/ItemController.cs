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
