using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Processor
{
    internal class Cell
    {
        private Environment _environment;

        private Func<bool> _checkLiveCondotions;

        public Cell(Environment environment, TwoDimPoint position, Func<bool> checkLiveConditions)
        {
            _environment = environment ?? throw new ArgumentNullException("Argument cannot be null", $"{nameof(environment)}");

            _checkLiveCondotions = checkLiveConditions;

            Position = position;
        }

        public TwoDimPoint Position { get; }

        public bool IsAlive => State == CellStates.Alive ? true : false;

        public CellStates State => _checkLiveCondotions() ? CellStates.Alive : CellStates.Dead;

        private void UpdateState()
        {
            foreach(Directions direction in Enum.GetValues(typeof(Directions)))
            {
                if (_environment.IsCellAlive(Position, Directions.N))
                {

                }
            }
        }
    }
}
