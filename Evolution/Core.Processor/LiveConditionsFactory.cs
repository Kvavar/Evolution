using System;

namespace Core.Processor
{
    internal class LiveConditionsFactory
    {
        private Func<TwoDimPoint, IEnvironment, bool> _simpleLiveConditions = (Position, _environment) => 
        {
            foreach (Directions direction in Enum.GetValues(typeof(Directions)))
            {
                if (_environment.IsCellAlive(Position, direction))
                {
                    return true;
                }
            }

            return false;
        };

        public Func<TwoDimPoint, IEnvironment, bool> Create(LiveConditionsTypes liveConditionsType)
        {
            switch(liveConditionsType)
            {
                case LiveConditionsTypes.Simple:
                    return _simpleLiveConditions;
                default:
                    throw new ArgumentOutOfRangeException($"{nameof(liveConditionsType)}");
            }
        }
    }
}
