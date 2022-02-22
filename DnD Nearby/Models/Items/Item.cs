using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnD_Nearby.Models
{
    public class Item
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public string DiscriptionURL { get; set; }

        public Item() { }
        public Item(int id, string name, float cost, string url) {
            this.ID = id;
            this.Name = name;
            this.Cost = cost;
            this.DiscriptionURL = url;
        }

        public virtual void UseItem() { }
    }
}
