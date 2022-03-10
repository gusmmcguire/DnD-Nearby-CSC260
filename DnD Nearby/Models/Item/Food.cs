using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Food : Item
    {
        public Food(string name, Coins cost, string descriptUrl, string imgUrl) : base(name, cost, descriptUrl, imgUrl) { }

        public override void UseItem()
        {
        }
    }
}
