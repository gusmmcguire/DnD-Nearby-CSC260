using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class CreatureInitPage
    {
        public KeyValuePair<Creature, int> creature { get; set; }
        public Creature currentCreature { get; set; }

        public CreatureInitPage(KeyValuePair<Creature, int> creature, Creature currentCreature)
        {
            this.creature = creature;
            this.currentCreature = currentCreature;
        }
    }
}
