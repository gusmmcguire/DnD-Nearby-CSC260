using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Models;

namespace DnD_Nearby.Models
{

    public class InitiativeTracker
    {
        public string encounterName { get; set; }
        public List<Creature> Creatures { get; set; }
        public Creature CurrentCreature { get; set; } = null;
        public int? CurrentInitiative { get; set; } = null;
        public Dictionary<Creature, int> CreatureInitiatives { get; set; } = new Dictionary<Creature, int>();

        public InitiativeTracker()
        {
            Creatures = new List<Creature>();
        }

        public InitiativeTracker(string id)
        {
            //Encounter encounter = new Encounter(id);

            //Creatures = encounter.Creatures;
        }

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
                (x.Key != CurrentCreature && y.Key != CurrentCreature)
                ? ((x.Value <= CurrentInitiative && y.Value <= CurrentInitiative)
                    ? ((x.Value > y.Value) ? x : y)
                    : CreatureInitiatives.Where(creature => creature.Key == CurrentCreature).First())
                : ((x.Key != CurrentCreature) ? x : y)
            );

            CurrentCreature = creature.Key;
            CurrentInitiative = creature.Value;
        }

        public void AddCreature(Creature creature, int initiative)
        {
            CreatureInitiatives.Add(creature, initiative);
        }

        public void RemoveCreature(Creature creature)
        {
            CreatureInitiatives.Remove(creature);
        }

        public void SetInitiative(Creature creature, int initiative)
        {
            if (CreatureInitiatives.ContainsKey(creature))
            {
                CreatureInitiatives[creature] = initiative;
            }
            else
            {
                AddCreature(creature, initiative);
            }
        }
    }
}
