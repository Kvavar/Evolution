using System;

namespace Evolution.Factor
{
    public class Selector
    {
        public Guid PropertyName { get; set; }
        public double UpperValue { get; set; }
        public double LowerValue { get; set; }
        public SelectorType Type { get; set; }
    }

    /// <summary>
    /// In - Property value should be between Upper and Lower
    /// Out - Property value shouldn`t be ...
    /// </summary>
    public enum SelectorType
    {
        None = 0,
        In = 1,
        Out = 2
    }
}
