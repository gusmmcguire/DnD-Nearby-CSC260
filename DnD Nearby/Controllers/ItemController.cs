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

        public IActionResult AddItem(ItemPage itemPage)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Mode = "";
                switch (itemPage.ItemType)
                {
                    case Enums.eItemType.ARMOR:
                        Armor a = (Armor)itemPage.Item;
                        a.Modifier = int.Parse(HttpContext.Request.Form["Modifier"]);
                        a.ACMod = int.Parse(HttpContext.Request.Form["ACMod"]);
                        itemService.Create(a);
                        break;
                    case Enums.eItemType.EQUIPMENT:
                        Equipment e = (Equipment)itemPage.Item;
                        e.Modifier = int.Parse(HttpContext.Request.Form["Modifier"]);
                        itemService.Create(e);
                        break;
                    case Enums.eItemType.FOOD:
                        Food f = (Food)itemPage.Item;
                        itemService.Create(f);
                        break;
                    case Enums.eItemType.TOOL:
                        Tool t = (Tool)itemPage.Item;
                        itemService.Create(t);
                        break;
                    case Enums.eItemType.WEAPON:
                        Weapon w = (Weapon)itemPage.Item;
                        w.Modifier = int.Parse(HttpContext.Request.Form["Modifier"]);
                        w.DamageMod = int.Parse(HttpContext.Request.Form["DamageMod"]);
                        itemService.Create(w);
                        break;
                    case Enums.eItemType.ITEM:
                        itemService.Create(itemPage.Item);
                        break;
                }
                itemService.Create(itemPage.Item);
                //ViewBag.ItemType = null;
                return Redirect("DisplayItems");
            }

            return View("ItemForm", itemPage);
        }

        public IActionResult EditItem(ItemPage itemPage)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Mode = "";
                itemService.Update(itemPage.Item.Id, itemPage.Item);
                return Redirect("DisplayItems");
            }

            return View("ItemForm", itemPage);
        }

        public IActionResult DeleteItem(Item item)
        {
            if (ModelState.IsValid)
            {
                itemService.Remove(item.Id);
                return Redirect("DisplayItems");
            }

            return View("DisplayItems", item);
        }

        public IActionResult AddItemForm(ItemPage itemPage)
        {
            ViewBag.Mode = "Add";
            return View("ItemForm", itemPage);
        }

        public IActionResult EditItemForm(ItemPage itemPage)
        {
            ViewBag.Mode = "Edit";
            return View("ItemForm", itemPage);
        }

        public IActionResult ReloadItemForm(ItemPage itemPage)
        {
            /*switch (itemPage.ItemType)
            {
                case Enums.eItemType.ITEM:
                    ViewBag.ItemType = "ITEM";
                    break;
                case Enums.eItemType.FOOD:
                    ViewBag.ItemType = "FOOD";
                    break;
                case Enums.eItemType.EQUIPMENT:
                    ViewBag.ItemType = "EQUIPMENT";
                    break;
                case Enums.eItemType.WEAPON:
                    ViewBag.ItemType = "WEAPON";
                    break;
                case Enums.eItemType.ARMOR:
                    ViewBag.ItemType = "ARMOR";
                    break;
                case Enums.eItemType.TOOL:
                    ViewBag.ItemType = "TOOL";
                    break;
            }*/
            return View("ItemForm", itemPage);
        }

        public IActionResult ItemForm()
        {
            return View();
        }
    }
}
