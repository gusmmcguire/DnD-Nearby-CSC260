using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Tool : Item
    {
        List<Item> components = new List<Item>();

        public Tool(int id, string name, float cost, string url) : base(id, name, cost, url)
        {
        }

        public Tool(int id, string name, float cost, string url, List<Item> components) : base(id, name, cost, url) 
        {
            this.components = components;
        }

        public override void UseItem() {}

        public void AddComponent(Item component)
        {
            components.Add(component);
        }

        public void RemoveComponent(Item component)
        {
            components.Remove(component);
        }

        public void RemoveComponent(int id)
        {
            components.RemoveAll(c => c.ID == id);
        }

        public void RemoveComponent(string name)
        {
            components.RemoveAll(c => c.Name == name);
        }
    }
}
