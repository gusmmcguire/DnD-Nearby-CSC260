using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Tool : Item
    {
        public List<Item> Components { get; } = new List<Item>();

        public Tool(int id, string name, Coins cost, string descriptUrl, string imgUrl) : base(id, name, cost, descriptUrl, imgUrl)
        {
        }

        public Tool(int id, string name, Coins cost, string descriptUrl, string imgUrl, List<Item> components) : base(id, name, cost, descriptUrl, imgUrl)
        {
            this.Components = components;
        }

        public override void UseItem() {}

        public void AddComponent(Item component)
        {
            Components.Add(component);
        }

        public void RemoveComponent(Item component)
        {
            Components.Remove(component);
        }

        public void RemoveComponent(int id)
        {
            Components.RemoveAll(c => c.ID == id);
        }

        public void RemoveComponent(string name)
        {
            Components.Remove(Components.Where(c => c.Name == name).First());
        }
    }
}
