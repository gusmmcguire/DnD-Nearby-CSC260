using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DnD_Nearby.Models;

namespace DnD_Nearby.Services
{
    public class PartialPlayerService
    {
        private readonly IMongoCollection<PlayerCharacter> characters;

        public PartialPlayerService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("D&DNearbyDB"));
            IMongoDatabase database = client.GetDatabase("D&D-Nearby");
            characters = database.GetCollection<PlayerCharacter>("Encounter Players");
        }

        public List<PlayerCharacter> Get()
        {
            return characters.Find(character => true).ToList();
        }

        public PlayerCharacter GetPlayerCharacter(string id)
        {
            return characters.Find(character => character.Id == id).FirstOrDefault();
        }

        public PlayerCharacter GetPlayerCharacter(PlayerCharacter ch)
        {
            return characters.Find(character => character.Name == ch.Name).FirstOrDefault();
        }

        public List<PlayerCharacter> GetPlayerCharactersByAccount(string userId)
        {
            var tempList = new List<PlayerCharacter>();
            foreach (var pc in characters.Find(acc => true).ToList())
            {
                if (pc.accountId.ToString().ToUpper() == userId.ToUpper())
                {
                    tempList.Add(pc);
                }
            }
            return tempList;
        }

        public PlayerCharacter Create(PlayerCharacter character)
        {
            characters.InsertOne(character);
            return character;
        }

        public void Update(string id, PlayerCharacter characterIn)
        {
            characters.ReplaceOne(character => character.Id == id, characterIn);
        }

        public void Remove(PlayerCharacter chIn)
        {
            characters.DeleteOne(character => character.Id == chIn.Id);
        }

        public void Remove(string id)
        {
            characters.DeleteOne(character => character.Id == id);
        }
    }
}
