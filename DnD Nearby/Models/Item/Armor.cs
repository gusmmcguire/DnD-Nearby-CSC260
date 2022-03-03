using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnD_Nearby.Models
{
    public class Armor : Equipment
    {
        [BsonElement("ACMod")]
        public int ACMod { get; set; }

        public Armor(string id, string name, Coins cost, string descriptUrl, string imgUrl, bool isEquip = false, int modifier = 0, int acMod = 0) : 
            base(id, name, cost, descriptUrl, imgUrl, isEquip, modifier)
        {
            this.ACMod = acMod;
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
