using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using DnD_Nearby.ValidationAttributes;

namespace DnD_Nearby.Models
{
    [AccountValidation]
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Username")]
        [Required]
        public string Username { get; set; }

        [BsonElement("Password")]
        [Required]
        public string Password { get; set; }
        
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        
        [BsonElement("LastName")]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
