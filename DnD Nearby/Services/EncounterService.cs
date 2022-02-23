using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DnD_Nearby.Models;

namespace DnD_Nearby.Services
{
    public class EncounterService
    {
        private readonly IMongoCollection<Encounter> encounters;

        public EncounterService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("D&DNearbyDB"));
            IMongoDatabase database = client.GetDatabase("D&D-Nearby");
            encounters = database.GetCollection<Encounter>("Combat Encounters");
        }

        public List<Encounter> Get()
        {
            return encounters.Find(encounter => true).ToList();
        }

        public List<Encounter> GetEncountersByAccount(string accountId)
        {
            return encounters.Find(encounter => encounter.accountId == accountId).ToList();
        }

        public Encounter GetEncounter(string id)
        {
            return encounters.Find(encounter => encounter.accountId == id).FirstOrDefault();
        }

        public void Create(Encounter encounter)
        {
            encounters.InsertOne(encounter);
        }

        public void Update(string id, Encounter encounterIn)
        {
            encounters.ReplaceOne(encounter => encounter.ID == id, encounterIn);
        }

        public void Remove(Encounter encounterIn)
        {
            encounters.DeleteOne(encounters => encounters.ID == encounterIn.ID);
        }

        public void Remove(string id)
        {
            encounters.DeleteOne(encounters => encounters.ID == id);
        }
    }
}
