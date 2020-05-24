using Evolution.Model;
using System;

namespace Evolution.Factor
{
    public class Selector : ISelector
    {
        private readonly Guid _propertyName;
        private readonly double _upperValue;
        private readonly double _lowerValue;
        private readonly SelectorRange _range;

        public Selector(Guid propertyName, double upperValue, double lowerValue, SelectorRange range)
        {
            _propertyName = propertyName;
            _upperValue = upperValue;
            _lowerValue = lowerValue;
            _range = range;
        }

        public SelectorType Type { get; }

        public bool Examine(Creature creature)
        {
            if (creature.Properties.TryGetValue(_propertyName, out var value))
            {
                switch (_range)
                {
                    case SelectorRange.In:
                        return _lowerValue <= value && value <= _upperValue;
                    case SelectorRange.Out:
                        return value <= _lowerValue && _upperValue <= value;
                    default:
                        throw new IndexOutOfRangeException($"Selector type is invalid.");
                }
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// In - Property value should be between Upper and Lower
    /// Out - Property value shouldn`t be ...
    /// </summary>
    public enum SelectorRange
    {
        None = 0,
        In = 1,
        Out = 2
    }

    public enum SelectorType
    {
        None = 0,
        NonCritical = 1,
        Critical = 2
    }
}
