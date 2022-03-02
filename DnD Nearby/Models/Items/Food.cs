using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Food : Item
    {
        public Food(int id, string name, Coins cost, string descriptUrl, string imgUrl) : base(id, name, cost, descriptUrl, imgUrl) { }

        public override void UseItem()
        {
        }
    }
}
