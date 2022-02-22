using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DnD_Nearby.Models;

namespace DnD_Nearby.Services
{
    public class SpellService
    {
        private readonly IMongoCollection<Spell> spells;

        public SpellService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("D&DNearbyDB"));
            IMongoDatabase database = client.GetDatabase("SpellBois");
            spells = database.GetCollection<Spell>("Spells");
        }

        public List<Spell> Get()
        {
            return spells.Find(spell => true).ToList();
        }

        public Spell GetSpellByName(string spellName)
        {
            return spells.Find(spell => spell.spellName == spellName).FirstOrDefault();
        }

        public Spell GetSpell(string id)
        {
            return spells.Find(spell => spell.Id == id).FirstOrDefault();
        }
        public Spell GetSpell(Spell sp)
        {
            return spells.Find(spell => spell == sp).FirstOrDefault();
        }

        public Spell Create(Spell sp)
        {
            spells.InsertOne(sp);
            return sp;
        }

        public void Update(string id, Spell spIn)
        {
            spells.ReplaceOne(spell => spell.Id == id, spIn);
        }

        public void Remove(Spell spIn)
        {
            spells.DeleteOne(spell => spell.Id == spIn.Id);
        }

        public void Remove(string id)
        {
            spells.DeleteOne(spell => spell.Id == id);
        }
    }
}
