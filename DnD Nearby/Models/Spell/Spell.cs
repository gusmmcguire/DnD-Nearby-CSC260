using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DnD_Nearby.Models
{
    public class Spell
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("spell_level")]
        public int spellLevel { get; set; }
        [BsonElement("spell_name")]
        public string spellName { get; set; }
        [BsonElement("spell_school")]
        public string spellSchool { get; set; }
        [BsonElement("spell_casting_time")]
        public string spellCast { get; set; }
        [BsonElement("spell_range")]
        public string spellRange { get; set; }
        [BsonElement("spell_duration")]
        public string spellDuration { get; set; }
        [BsonElement("spell_components")]
        public string spellComponent { get; set; }
        [BsonElement("aquired_classes")]
        public string aquiredClasses { get; set; }
        [BsonElement("spell_description")]
        public string spellDescription { get; set; }


        public Spell() { }

        public Spell(int level, string name, string school, string castingTime, string range, string duration, string components, string spellAquiredBy, string description)
        {
            spellLevel = level;
            spellName = name;
            spellSchool = school;
            spellCast = castingTime;
            spellRange = range;
            spellDuration = duration;
            spellComponent = components;
            aquiredClasses = spellAquiredBy;
            spellDescription = description;
        }
    }
}
