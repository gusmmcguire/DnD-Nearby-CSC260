using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class StatBlockEncounterPartialPage
    {
        public List<string> CreatureRef;
        public StatBlock statForPage { get; set; }

        public StatBlockEncounterPartialPage(ref List<string> creatureRef, StatBlock stat)
        {
            CreatureRef = creatureRef;
            statForPage = stat;
        }
    }
}
