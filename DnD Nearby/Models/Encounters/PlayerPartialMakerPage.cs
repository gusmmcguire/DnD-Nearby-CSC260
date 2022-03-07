using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class PlayerPartialMakerPage
    {
        public List<string> CreatureRef;
        public PlayerCharacter pcForPage { get; set; }

        public PlayerPartialMakerPage() { }
        public PlayerPartialMakerPage(ref List<string> creatureRef)
        {
            CreatureRef = creatureRef;
        }
    }
}
