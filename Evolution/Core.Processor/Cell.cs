using System;

namespace Core.Processor
{
    internal class Cell
    {
        private IEnvironment _environment;

        private Func<TwoDimPoint, IEnvironment, bool> _checkLiveConditions;

        public Cell(IEnvironment environment, TwoDimPoint position, Func<TwoDimPoint, IEnvironment, bool> checkLiveConditions)
        {
            _environment = environment ?? throw new ArgumentNullException("Argument cannot be null", $"{nameof(environment)}");

            _checkLiveConditions = checkLiveConditions;

            Position = position;
        }

        public TwoDimPoint Position { get; }

        public bool IsAlive => State == CellStates.Alive ? true : false;

        public CellStates State { get; set; }

        public void UpdateState()
        {
            State = _checkLiveConditions(Position, _environment) ? CellStates.Alive : CellStates.Dead;
        }
    }
}
