using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Enums;

namespace DnD_Nearby.Models
{
    public class EncounterPage
    {
        private Encounter _encounter = new Encounter();
        public Encounter encounter { get { return _encounter; } set { _encounter = value; } }

        public List<StatBlock> StatBlocks { get; set; } = new List<StatBlock>();
        public List<PlayerCharacter> PlayerCharacters { get; set; } = new List<PlayerCharacter>();

        public eDifficulty? diff = null;
    }
}
