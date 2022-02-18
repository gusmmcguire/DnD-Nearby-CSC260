using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using DnD_Nearby.ValidationAttributes;
using DnD_Nearby.Enums;

namespace DnD_Nearby.Models
{
    public class StatBlock : Creature
    {
        [BsonElement("ChallengeRating")]
        public eCR CR { get; set; }

        public StatBlock(eCR cr, string name, string race, int[] attributes, int maxHP, int ac, List<string> languages, List<Item> inventory = null) : base(name, race, attributes, maxHP, ac, languages, inventory)
        {
            CR = cr;
        }
    }
}
