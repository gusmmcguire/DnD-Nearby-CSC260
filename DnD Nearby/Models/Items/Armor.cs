using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Armor : Equipment
    {
        public int ACMod { get; set; }

        public Armor(int id, string name, float cost, string url, bool isEquip, int modifier, int acMod): base(id, name, cost, url, isEquip, modifier)
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
