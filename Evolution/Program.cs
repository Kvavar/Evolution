using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Evolution.Model;

namespace Evolution
{
    class Program
    {
        private static double BaseValue = 10.0;
        private static int NumberOfCreatures = 100;
        private static int NumberOfProperties = 40;
        private static int MinimumPropertiesExceedToTakeOver = 5;
        private static Random Rand = new Random();
        private static int AvarageBasis = 100;
        private static int NormBasis = 60;

        private static List<Creature> Creatures = new List<Creature>();
        private static List<Guid> Properties = new List<Guid>();

        static void Main(string[] args)
        {
            var aliveToPlot = new List<PlotPoint>(NumberOfProperties);
            for (int n = 1; n <= NumberOfProperties; n++)
            {
                var cumulativeAlive = 0;
                for (int i = 0; i < AvarageBasis; i++)
                {
                    Create();
                    cumulativeAlive += Eliminate(n);
                }

                var average = cumulativeAlive / (double)AvarageBasis;
                /*var percentage = (average / ((double)NumberOfCreatures)) * 100.0;
                Console.WriteLine($"For {n} criterias average alive percentage: {percentage}");*/
                aliveToPlot.Add(new PlotPoint { X = n, Y = average / ((double)NumberOfCreatures) });
            }

            var maxY = aliveToPlot.Max(p => p.Y);
            aliveToPlot = aliveToPlot.Select(p => new PlotPoint {X = p.X, Y = (p.Y / maxY) * NormBasis }).ToList();

            for (int i = 0; i < NormBasis; i++)
            {
                var sb = new StringBuilder();
                foreach (var point in aliveToPlot)
                {
                    sb.Append(point.Y >= maxY * NormBasis - i ? "*****" : "     ");
                }

                Console.WriteLine(sb.ToString());
            }

            Console.ReadLine();
        }

        private static void Create()
        {
            Properties = new List<Guid>(new int[NumberOfProperties].Select(_ => Guid.NewGuid()));
            Creatures = new List<Creature>(new int[NumberOfCreatures].Select(_ => new Creature
            (
                Properties.ToDictionary(name => name, _ => BaseValue + Rand.NextDouble()),
                Properties.ToDictionary(name => name, _ => BaseValue + Rand.NextDouble())
            )));
        }

        private static void Start()
        {
            //TODO Gender preference, Availability for better
            for (int i = 0; i < Creatures.Count; i++)
            {
                var creature = Creatures[i];
                for (int j = 0; j < Creatures.Count; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }

                    var candidate = Creatures[j];
                    var isMatch = true;

                    foreach (var pref in creature.Preferences)
                    {
                        if (candidate.Properties.TryGetValue(pref.Key, out var value))
                        {
                            var compare = pref.Value / value;
                            if (compare < 0.95 || 1.05 < compare)
                            {
                                isMatch = false;
                                break;
                            }
                        }
                    }

                    if(isMatch)
                    {
                        if(!candidate.Available)
                        {
                            var propCount = 0;
                            foreach (var prop in creature.Properties)
                            {
                                if (candidate.Couple.Properties.TryGetValue(prop.Key, out var value))
                                {
                                    if(prop.Value > value)
                                    {
                                        propCount++;
                                    }
                                    else
                                    {
                                        propCount--;
                                    }
                                }
                            }

                            if(propCount <= MinimumPropertiesExceedToTakeOver)
                            {
                                //Console.WriteLine($"Unable to take because of {Math.Abs(propCount)} properties.");
                                continue;
                            }

                            //Console.WriteLine($"Successfully took by {propCount} properties.");
                            candidate.Couple.Couple = null;
                        }

                        candidate.Couple = creature;
                        creature.Couple = candidate;

                        //Console.WriteLine("Found");
                    }
                }
            }

            Console.WriteLine("Done");
        }

        private static int Eliminate(int criteriasNumber)
        {
            var criterias = Properties.ToDictionary(name => name, _ => BaseValue + Rand.NextDouble());

            foreach (var creature in Creatures)
            {
                var criteriaCount = 0;

                foreach (var prop in creature.Properties)
                {
                    if(criterias.TryGetValue(prop.Key, out var value))
                    {
                        if(prop.Value <= value)
                        {
                            criteriaCount++;
                            if(criteriaCount == criteriasNumber)
                            {
                                creature.Alive = false;
                                break;
                            }
                        }
                    }
                }
            }

            var alive = Creatures.Count(c => c.Alive);

            return alive;
        }
    }

    public class Property
    {
        public Property(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public double Value { get; }
    }

    public class Preferences
    {
        public Preferences(string name, double min, double max)
        {
            Name = name;
            Min = min;
            Max = max;
        }

        public string Name { get; }
        public double Min { get; }
        public double Max { get; }
    }

    public struct PlotPoint
    {
        public int X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return $"X: {X} Y: {Y}";
        }
    }
}
