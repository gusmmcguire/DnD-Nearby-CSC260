using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnD_Nearby.Models
{
    [BsonIgnoreExtraElements]
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ItemName")]
        [Required]
        public string Name { get; set; }

        [BsonElement("Cost")]
        public Coins Cost { get; set; }
        
        [BsonElement("DescriptionURL")]
        public string DescriptionURL { get; set; }
        [BsonElement("ImageURL")]
        public string ImageURL { get; set; }

        public Item() { }
        public Item(string name, Coins cost, string descriptUrl, string imgUrl) {
            this.Name = name;
            this.Cost = cost;
            this.DescriptionURL = descriptUrl;
            this.ImageURL = imgUrl;
        }

        public virtual void UseItem() { }
    }
}
