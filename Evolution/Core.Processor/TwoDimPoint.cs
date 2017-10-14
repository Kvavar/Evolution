namespace Core.Processor
{
    internal struct TwoDimPoint
    {
        public TwoDimPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }
}
