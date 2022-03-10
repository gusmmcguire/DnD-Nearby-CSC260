using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class InitiativePage
    {
        public InitiativeTracker initTracker { get; set; } = new InitiativeTracker();
        public Encounter encounter { get; set; } = new Encounter();

        public InitiativePage() { }
        public InitiativePage(Encounter en)
        {
            DiceRoller diceRoller = new DiceRoller();
            encounter = en;
            foreach (Creature creature in encounter.Creatures)
            {
                initTracker.AddCreature(creature, diceRoller.RollDice(20) + creature.CalcAttributeMod(1));
            }
            initTracker.NextCreature();
        }
        public InitiativePage(Encounter en, int[] initiatives)
        {
            DiceRoller diceRoller = new DiceRoller();
            encounter = en;
            int index = 0;
            foreach (Creature creature in encounter.Creatures)
            {
                initTracker.AddCreature(creature, initiatives[index++]);
            }
            initTracker.NextCreature();
        }
        public InitiativePage(Encounter en, int[] initiatives, string currentCreatureName, int currentInit, string previousCreatureName = null)
        {
            DiceRoller diceRoller = new DiceRoller();
            encounter = en;
            int index = 0;
            foreach (Creature creature in encounter.Creatures)
            {
                initTracker.AddCreature(creature, initiatives[index++]);
            }
            initTracker.CurrentInitiative = currentInit;
            initTracker.CurrentCreature = initTracker.CreatureInitiatives.First(creature => creature.Key.Name == currentCreatureName).Key;
            initTracker.PreviousCreature = initTracker.CreatureInitiatives.FirstOrDefault(creature => creature.Key.Name == previousCreatureName).Key;
        }
    }
}
