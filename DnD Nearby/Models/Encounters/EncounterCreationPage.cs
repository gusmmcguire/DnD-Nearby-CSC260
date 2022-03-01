using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Services;

namespace DnD_Nearby.Models
{
    public class EncounterCreationPage
    {
        public EncounterCreationPage() { }
        public EncounterCreationPage(List<StatBlock> statBlocks)
        {
            encounter = new Encounter();
            statCollection = statBlocks;
        }


        public List<string> creatureIDs = new List<string>();
        public string[] CreatureIDs { get { return creatureIDs.ToArray(); } set { creatureIDs = value.ToList(); } }
        public Encounter encounter { get; set; }
        public List<StatBlock> statCollection { get; set; }
        public string displayString { get; set; }
        public string accountName { get; set; }

        public void setupString(StatBlockService sbS, PlayerCharacterService pcS)
        {
            List<StatBlock> stats = sbS.Get();
            List<PlayerCharacter> players = pcS.Get();
            displayString = "Creatures in Encounter: ";
            foreach (string id in CreatureIDs)
            {
                bool found = false;
                foreach (StatBlock stat in stats)
                {
                    if (id == stat.Id)
                    {
                        displayString += stat.Name + ", ";
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    foreach (PlayerCharacter pc in players)
                    {
                        if (id == pc.Id)
                        {
                            displayString += pc.Name + ", ";
                            found = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
