using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DnD_Nearby.Models;

namespace DnD_Nearby.Services
{
    public class StatBlockService
    {
        private readonly IMongoCollection<StatBlock> statBlocks;

        public StatBlockService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("D&DNearbyDB"));
            IMongoDatabase database = client.GetDatabase("D&D-Nearby");
            statBlocks = database.GetCollection<StatBlock>("Stat Blocks");
        }

        public List<StatBlock> Get()
        {
            return statBlocks.Find(stat => true).ToList();
        }

        public List<StatBlock> GetStatBlocksByAccount(string userId)
        {
            var tempList = new List<StatBlock>();
            foreach (var stat in statBlocks.Find(acc => true).ToList())
            {
                if (stat.accountId.ToString().ToUpper() == userId.ToUpper())
                {
                    tempList.Add(stat);
                }
            }
            return tempList;
        }

        public StatBlock GetStatBlock(string id)
        {
            return statBlocks.Find(stat => stat.Id == id).FirstOrDefault();
        }

        public StatBlock GetStatBlock(StatBlock st)
        {
            return statBlocks.Find(stat => stat.Name == st.Name).FirstOrDefault();
        }

        public StatBlock Create(StatBlock stat)
        {
            statBlocks.InsertOne(stat);
            return stat;
        }

        public void Update(string id, StatBlock statIn)
        {
            statBlocks.ReplaceOne(stat => stat.Id == id, statIn);
        }

        public void Remove(StatBlock stIn)
        {
            statBlocks.DeleteOne(stat => stat.Id == stIn.Id);
        }

        public void Remove(string id)
        {
            statBlocks.DeleteOne(stat => stat.Id == id);
        }
    }
}
