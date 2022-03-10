using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnD_Nearby.Enums;

namespace DnD_Nearby.Models
{
    public class ItemPage
    {
        public Item Item { get; set; }

        public eItemType? ItemType { get; set; } = null;
    }
}
