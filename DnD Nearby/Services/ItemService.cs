using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DnD_Nearby.Models;

namespace DnD_Nearby.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> items;

        public ItemService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("D&DNearbyDB"));
            IMongoDatabase database = client.GetDatabase("D&D-Nearby");
            items = database.GetCollection<Item>("Items");
        }

        public List<Item> Get()
        {
            return items.Find(item => true).ToList();
        }

        public Item GetItem(string id)
        {
            return items.Find(item => item.Id == id).FirstOrDefault();
        }

        public Item GetItem(Item it)
        {
            return items.Find(item => item.Name == it.Name).FirstOrDefault();
        }

        public Item Create(Item item)
        {
            items.InsertOne(item);
            return item;
        }

        public Armor Create(Armor item)
        {
            items.InsertOne(item);
            return item;
        }

        public Food Create(Food item)
        {
            items.InsertOne(item);
            return item;
        }

        public Weapon Create(Weapon item)
        {
            items.InsertOne(item);
            return item;
        }

        public Equipment Create(Equipment item)
        {
            items.InsertOne(item);
            return item;
        }

        public Tool Create(Tool item)
        {
            items.InsertOne(item);
            return item;
        }

        public void Update(string id, Item itemIn)
        {
            items.ReplaceOne(item => item.Id == id, itemIn);
        }

        public void Remove(Item itIn)
        {
            items.DeleteOne(item => item.Id == itIn.Id);
        }

        public void Remove(string id)
        {
            items.DeleteOne(item => item.Id == id);
        }
    }
}
