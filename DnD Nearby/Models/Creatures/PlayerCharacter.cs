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
    public class PlayerCharacter : Creature
    {
        [BsonElement("PlayerName")]
        [Required]
        public string Player { get; set; }

        [BsonElement("CharacterClass")]
        [Required]
        public string Class { get; set; }

        [BsonElement("CharacterLevel")]
        [Required]
        public int Level { get; set; }

        [BsonElement("CharacterBackground")]
        [Required]
        public string Background { get; set; }

        [BsonElement("CharacterFeats")]
        [Required]
        public List<string> Feats { get; set; }

        [BsonElement("Experience")]
        [Required]
        public int exp { get; set; }

        //copper, silver, electrum, gold, platinum
        [BsonElement("Coins")]
        [Required]
        public int[] coins { get; set; }

        public PlayerCharacter(string name, string race, int[] attributes, int maxHP, int ac, List<string> languages, string player, string classIn, int level, string background, List<string> feats, List<Item> inventory = null) : base(name, race, attributes, maxHP, ac, languages, inventory)
        {
            this.Player = player;
            this.Class = classIn;
            this.Level = level;
            this.Background = background;
            this.Feats = feats;
        }
    }
}
