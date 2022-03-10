using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnD_Nearby.Models
{
    public class Equipment : Item
    {
        [BsonElement("IsEquipped")]
        public bool IsEquipped { get; set; }
        [BsonElement("Modifier")]
        public int Modifier { get; set; }

        public Equipment(string name, Coins cost, string descriptUrl, string imgUrl, bool isEquipped = false, int modifier = 0) : base(name, cost, descriptUrl, imgUrl)
        {
            this.IsEquipped = IsEquipped;
            this.Modifier = modifier;
        }
        public override void UseItem() {}
        
        protected int[] ModStats(int[] attributes, int attribIndex)
        {
            int[] moddedStats = attributes;

            if (IsEquipped)
                moddedStats[attribIndex] += Modifier;
            else
                moddedStats[attribIndex] -= Modifier;

            return moddedStats;
        }

        public virtual void Equip(int[] attributes, int modAttribIndex) { }
        public virtual void Unequip(int[] attributes, int modAttribIndex) { }
    }
}
