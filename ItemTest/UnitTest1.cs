using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnD_Nearby.Models;
using System.Collections.Generic;

namespace ItemTest
{
    [TestClass]
    public class UnitTest1
    {
        private static int[] playerStats = new int[]{ 10, 14, 8, 15, 18, 10 };

        private static List<Item> items = new List<Item>()
        {
            new Armor(1, "Chestplate", 1.50f, "no", true, 7, 6),
            new Weapon(2, "Sword", 1.25f, "no", false, 5, 2),
            new Food(3, "Apple", 0.5f, "no"),
            new Item(4, "Map", 0.0f, "no"),
            new Tool(5, "Adventurer's Pack", 2.0f, "no")
        };

        [TestMethod]
        public void EquipWeapon()
        {
            Weapon weapon = (Weapon)items[1];
            weapon.Equip(playerStats, 2);

            Assert.AreEqual(playerStats[2], 13);
        }

        [TestMethod]
        public void UnequipWeapon()
        {
            Weapon weapon = (Weapon)items[1];
            weapon.Unequip(playerStats, 2);

            Assert.AreEqual(playerStats[2], 8);
        }

        [TestMethod]
        public void EquipArmor()
        {
            Armor armor = (Armor)items[0];
            armor.Equip(playerStats, 0);

            Assert.AreEqual(playerStats[0], 17);
        }

        [TestMethod]
        public void UnequipArmor()
        {
            Armor armor = (Armor)items[0];
            armor.Unequip(playerStats, 0);

            Assert.AreEqual(playerStats[0], 10);
        }

        [TestMethod]
        public void AddComponents()
        {
            Tool tool = (Tool)items[4];

            tool.AddComponent(new Item(1, "Paper", 0.5f, "test"));
            tool.AddComponent(new Item(2, "Pen", 0.5f, "test"));
            tool.AddComponent(new Item(3, "Ink", 0.5f, "test"));
            tool.AddComponent(new Item(4, "Ink", 0.5f, "test"));

            Assert.AreEqual(tool.Components.Count, 4);
        }

        [TestMethod]
        public void RemoveComponent()
        {
            Tool tool = (Tool)items[4];

            tool.RemoveComponent(tool.Components[0]);

            Assert.AreEqual(tool.Components.Count, 3);
        }

        [TestMethod]
        public void RemoveComponentByID()
        {
            Tool tool = (Tool)items[4];

            tool.RemoveComponent(2);

            Assert.AreEqual(tool.Components.Count, 2);
        }

        [TestMethod]
        public void RemoveComponentByName()
        {
            Tool tool = (Tool)items[4];

            tool.RemoveComponent("Ink");

            Assert.AreEqual(tool.Components.Count, 1);
        }
    }
}
