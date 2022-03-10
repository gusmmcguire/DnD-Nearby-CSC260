using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Models;

namespace DnD_Nearby.Models
{

    public class InitiativeTracker
    {
        public Creature PreviousCreature { get; set; } = null;
        public Creature CurrentCreature { get; set; } = null;
        public int? CurrentInitiative { get; set; } = null;
        public Dictionary<Creature, int> CreatureInitiatives { get; set; } = new Dictionary<Creature, int>();

        public InitiativeTracker() {}

        public void NextCreature()
        {
            if (CreatureInitiatives.Count == 0) return;

            KeyValuePair<Creature, int> creature;

            if (CurrentInitiative == null)
            {
                creature = CreatureInitiatives.Aggregate((x, y) => (x.Value > y.Value) ? x : y);
                CurrentCreature = creature.Key;
                CurrentInitiative = creature.Value;
                
                return;
            }

            creature = CreatureInitiatives.Aggregate((x, y) =>
                (x.Key != CurrentCreature && y.Key != CurrentCreature) // if x and y are not equal to the current creature, continue. Otherwise return whichever isn't the current one
                    ? (x.Key != PreviousCreature && y.Key != PreviousCreature) // if x and y are not equal to the previous creature, continue. Otherwise return whichever isn't the previous one
                        ? (x.Value <= CurrentInitiative && y.Value <= CurrentInitiative) // if x and y's initiatives are less than or equel to the current initiative, continue. Otherwise see if either are.
                            ? (x.Value > y.Value) ? x : y // return whichever has a greater value
                        : (x.Value <= CurrentInitiative) // if x's value is less than current initiative, return x
                            ? x
                        : (y.Value <= CurrentInitiative) // if y's value is less than current initiative, return y
                            ? y
                        : CreatureInitiatives.Aggregate((x, y) => (x.Value > y.Value) ? x : y) // return the Creature with the highest initiative
                    : (x.Key != PreviousCreature) ? x : y // return whichever isn't the previous one
                : (x.Key != CurrentCreature) ? x : y // return whichever isn't the current one
            );

            PreviousCreature = CurrentCreature;
            CurrentCreature = creature.Key;
            CurrentInitiative = creature.Value;
        }

        public void AddCreature(Creature creature, int initiative)
        {
            CreatureInitiatives.TryAdd(creature, initiative);
        }

        public void RemoveCreature(Creature creature)
        {
            CreatureInitiatives.Remove(creature);
        }
    }
}
