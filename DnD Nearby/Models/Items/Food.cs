using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Food : Item
    {
        public Food(int id, string name, float cost, string url) : base(id, name, cost, url) { }

        public override void UseItem()
        {
        }
    }
}
