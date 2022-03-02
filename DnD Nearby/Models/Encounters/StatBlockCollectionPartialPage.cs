using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class StatBlockCollectionPartialPage
    {
        public List<StatBlock> statBlocks { get; set; }
        public List<string> creatures;

        public StatBlockCollectionPartialPage(ref List<string> creatures, List<StatBlock> stats)
        {
            this.creatures = creatures;
            this.statBlocks = stats;
        }
    }
}
