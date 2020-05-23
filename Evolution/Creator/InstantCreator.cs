using Evolution.Model;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Evolution.Creator
{
    public class InstantCreator : ICreator
    {
        private readonly IRandom _random;
        private readonly int _numberOfProps;
        private readonly int _numbefOfCreatures;

        public InstantCreator(IRandom random, int numberOfProps, int numbefOfCreatures)
        {
            _random = random;
            _numberOfProps = numberOfProps;
            _numbefOfCreatures = numbefOfCreatures;
        }
        public List<Creature> Create()
        {
            var properties = new List<Guid>(new int[_numberOfProps].Select(_ => Guid.NewGuid()));
            return new List<Creature>(new int[_numbefOfCreatures].Select(_ => new Creature
            (
                properties.ToDictionary(name => name, _ => _random.NextDouble()),
                properties.ToDictionary(name => name, _ => _random.NextDouble())
            )));
        }
    }
}
