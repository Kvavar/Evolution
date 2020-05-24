using System;
using System.Linq;
using System.Collections.Generic;
using Evolution.Model;

namespace Evolution.Factor
{
    public class NaturalSelection : ISelection
    {
        private readonly IReadOnlyList<ISelector> _selectors;

        public NaturalSelection(IReadOnlyList<ISelector> selectors)
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
                    passed = selector.Examine(creature);

                    if(!passed)
                    {
                        if(selector.Type == SelectorType.Critical)
                        {
                            break;
                        }
                        else
                        {
                            //todo what if criteria is not critical
                        }
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
