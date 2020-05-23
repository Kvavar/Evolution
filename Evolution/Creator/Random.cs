using System;

namespace Evolution.Creator
{
    public class Random : IRandom
    {
        private readonly Random _random;

        public Random()
        {
            _random = new Random();
        }
        public double NextDouble()
        {
            return _random.NextDouble();
        }
    }
}
