using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Equipment : Item
    {
        public bool IsEquipped { get; set; }
        public int Modifier { get; set; }

        public Equipment(int id, string name, float cost, string url, bool isEquipped, int modifier) : base(id, name, cost, url)
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
