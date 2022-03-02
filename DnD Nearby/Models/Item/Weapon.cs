using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnD_Nearby.Models
{
    public class Weapon : Equipment
    {
        [BsonElement("DamageMod")]
        public int DamageMod { get; set; }

        public Weapon(string id, string name, Coins cost, string descriptUrl, string imgUrl, bool isEquipped = false, int modifier = 0, int damageMod = 0) : 
            base(id, name, cost, descriptUrl, imgUrl, isEquipped, modifier)
        {
            this.DamageMod = damageMod;
        }

        public override void Equip(int[] attributes, int modAttribIndex)
        {
            if (IsEquipped) return;

            IsEquipped = true;
            attributes = ModStats(attributes, modAttribIndex);
        }

        public override void Unequip(int[] attributes, int modAttribIndex)
        {
            if (!IsEquipped) return;

            IsEquipped = false;
            attributes = ModStats(attributes, modAttribIndex);
        }
    }
}
