using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Weapon : Equipment
    {
        public int DamageMod { get; set; }

        public Weapon(int id, string name, float cost, string url, bool isEquipped, int modifier, int damageMod): base(id, name, cost, url, isEquipped, modifier) 
        {
            this.DamageMod = damageMod;
        }

        public override void Equip(ref int[] attributes, int modAttribIndex)
        {
            if (IsEquipped) return;

            IsEquipped = true;
            attributes = ModStats(attributes, modAttribIndex);
        }

        public override void Unequip(ref int[] attributes, int modAttribIndex)
        {
            if (!IsEquipped) return;

            IsEquipped = false;
            attributes = ModStats(attributes, modAttribIndex);
        }
    }
}
