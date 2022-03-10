using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnD_Nearby.Models
{
    public class Tool : Item
    {
        [BsonElement("Components")]
        public List<Item> Components { get; private set; } = new List<Item>();

        public Tool(string name, Coins cost, string descriptUrl, string imgUrl) : base(name, cost, descriptUrl, imgUrl)
        {
        }

        public Tool(string name, Coins cost, string descriptUrl, string imgUrl, List<Item> components = null) : base(name, cost, descriptUrl, imgUrl)
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

        public void RemoveComponentByID(string id)
        {
            Components.RemoveAll(c => c.Id == id);
        }

        public void RemoveComponentByName(string name)
        {
            Components.Remove(Components.Where(c => c.Name == name).First());
        }
    }
}
