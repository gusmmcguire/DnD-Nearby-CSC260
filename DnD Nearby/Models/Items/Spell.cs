using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Spell
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public string[] Components { get; set; }
        public string[] SpellAquiredBy { get; set; }
        public string Description { get; set; }

        public Spell() { }

        public Spell(string name, string school, string castingTime, string range, string duration,string[] components, string[] spellAquiredBy, string description )
        {
            Name = name;
            School = school;
            CastingTime = castingTime;
            Range = range;
            Duration = duration;
            Components = components;
            SpellAquiredBy = spellAquiredBy;
            Description = description;
        }

    }
}
