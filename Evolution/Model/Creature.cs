using System;
using System.Collections.Generic;

namespace Evolution.Model
{
    public class Creature
    {
        public Creature(Dictionary<Guid, double> properties, Dictionary<Guid, double> preferences)
        {
            Properties = properties;
            Preferences = preferences;
        }

        public Dictionary<Guid, double> Properties { get; }
        public Dictionary<Guid, double> Preferences { get; }

        public bool Available => Couple == null;
        public bool Alive { get; set; } = true;

        public Creature Couple { get; set; }
    }
}
