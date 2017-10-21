using System;

namespace Core.Processor
{
    internal class LiveConditionsFactory
    {
        private Func<TwoDimPoint, IEnvironment, bool> _simpleLiveConditions = (Position, _environment) => 
        {
            int count = 0;

            foreach (Directions direction in Enum.GetValues(typeof(Directions)))
            {
                if (_environment.IsCellAlive(Position, direction))
                {
                    count++;
                }
            }

            if(!_environment.IsHeaven(Position))
            {
                if (count > 2 && count < 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (count > 1 && count < 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
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
