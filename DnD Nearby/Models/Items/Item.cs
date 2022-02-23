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
        public Coins Cost { get; set; }
        public string DescriptionURL { get; set; }
        public string ImageURL { get; set; }

        public Item() { }
        public Item(int id, string name, Coins cost, string descriptUrl, string imgUrl) {
            this.ID = id;
            this.Name = name;
            this.Cost = cost;
            this.DescriptionURL = descriptUrl;
            this.ImageURL = imgUrl;
        }

        public virtual void UseItem() { }
    }
}
