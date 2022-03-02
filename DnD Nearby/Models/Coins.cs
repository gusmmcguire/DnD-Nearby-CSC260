using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public struct Coins
    {
        public int platium;
        public int gold;
        public int electrum;
        public int silver;
        public int copper;

        public Coins(int pp, int gp, int ep, int sp, int cp)
        {
            this.platium = pp;
            this.gold = gp;
            this.electrum = ep;
            this.silver = sp;
            this.copper = cp;
        }
    }
}
