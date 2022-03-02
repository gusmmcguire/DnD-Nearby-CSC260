using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Weapon : Equipment
    {
        public int DamageMod { get; set; }

        public Weapon(int id, string name, Coins cost, string descriptUrl, string imgUrl, bool isEquipped, int modifier, int damageMod) : 
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
