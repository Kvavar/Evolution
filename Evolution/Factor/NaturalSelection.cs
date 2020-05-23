using System;
using System.Linq;
using System.Collections.Generic;
using Evolution.Model;

namespace Evolution.Factor
{
    public class NaturalSelection : ISelection
    {
        private readonly IReadOnlyList<Selector> _selectors;

        public NaturalSelection(IReadOnlyList<Selector> selectors)
        {
            _selectors = selectors;
        }

        public List<Creature> Select(List<Creature> creatures)
        {
            var result = new List<Creature>();
            if(!creatures.Any())
            {
                return result;
            }

            foreach (var creature in creatures)
            {
                var passed = true;
                foreach (var selector in _selectors)
                {
                    if(creature.Properties.TryGetValue(selector.PropertyName, out var value))
                    {
                        switch(selector.Type)
                        {
                            case SelectorType.In:
                                passed = selector.LowerValue <= value && value <= selector.UpperValue;
                                break;
                            case SelectorType.Out:
                                passed = value <= selector.LowerValue && selector.UpperValue <= value;
                                break;
                            default:
                                throw new IndexOutOfRangeException($"Selector type is invalid.");
                        }
                    }

                    if(!passed)
                    {
                        break;
                    }
                }

                if(passed)
                {
                    result.Add(creature);
                }
            }

            return result;
        }
    }
}
