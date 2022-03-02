using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Armor : Equipment
    {
        public int ACMod { get; set; }

        public Armor(int id, string name, Coins cost, string descriptUrl, string imgUrl, bool isEquip, int modifier, int acMod) : 
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
