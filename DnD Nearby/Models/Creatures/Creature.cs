using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using DnD_Nearby.ValidationAttributes;

namespace DnD_Nearby.Models
{
    public class Creature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("account_id")]
        public Guid accountId { get; set; }

        [BsonElement("CreatureName")]
        [Required]
        public string Name { get; set; }

        [BsonElement("Race")]
        public string Race { get; set; }
        //str, dex, con, int, wis, char
        [BsonElement("Attributes")]
        public int[] Attributes { get; set; }

        [BsonElement("MaxHP")]
        [Required]
        public int MaxHP { get; set; }

        [BsonElement("CurrentHP")]
        public int CurrentHP { get; set; }

        [BsonElement("ArmorClass")]
        [Required]
        public int AC { get; set; }

        [BsonElement("Languages")]
        public List<string> Languages { get; set; }

        //store just spell name
        [BsonElement("Spells")]
        public List<string> Spells { get; set; }

        [BsonElement("Cantrips")]
        public List<string> Cantrips { get; set; }

        [BsonElement("Inventory")]
        public List<Item> Inventory { get; set; }


        public Creature() { }
        public Creature(string name, string race, int[] attributes, int maxHP, int ac, List<string> languages, List<Item> inventory = null)
        {
            this.Name = name;
            this.Race = race;
            this.Attributes = attributes;
            this.MaxHP = maxHP;
            this.CurrentHP = maxHP;
            this.Languages = languages;
            this.Inventory = inventory;
        }

        public virtual int[] CalcAttributeMods()
        {
            int[] tempArray = new int[6];
            for(int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = (Attributes[i] - 10 ) / 2;
            }
            return tempArray;
        }
        
        public virtual int CalcAttributeMod(int index)
        {
            int temp = (Attributes[index] - 10 )/ 2;
            return temp;
        }
    }
}
