using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnD_Nearby.Models
{
    public class Coins
    {
        [BsonElement]
        public int Platinum { get; set; } = 0;
        [BsonElement]
        public int Gold { get; set; } = 0;
        [BsonElement]
        public int Electrum { get; set; } = 0;
        [BsonElement]
        public int Silver { get; set; } = 0;
        [BsonElement]
        public int Copper { get; set; } = 0;

        public Coins() { }

        [BsonConstructor]
        public Coins(int pp, int gp, int ep, int sp, int cp)
        {
            this.Platinum = pp;
            this.Gold = gp;
            this.Electrum = ep;
            this.Silver = sp;
            this.Copper = cp;
        }
    }
}
