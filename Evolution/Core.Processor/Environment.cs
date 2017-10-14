using System;

namespace Core.Processor
{
    internal class Environment
    {
        private Cell[,] _cells;

        public void AddOrRelaceCell(Cell cell)
        {
            _cells[cell.Position.X, cell.Position.Y] = cell;
        }

        public bool IsCellAlive(TwoDimPoint startPosition , Directions direction)
        {
            int shiftX = 0;
            int shiftY = 0;

            switch (direction)
            {
                case Directions.N:
                case Directions.NE:
                case Directions.NW:
                    shiftY = --shiftY;
                    break;
                case Directions.S:
                case Directions.SE:
                case Directions.SW:
                    shiftY = ++shiftY;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"nameof{ direction }");
            }

            switch(direction)
            {
                case Directions.E:
                case Directions.NE:
                case Directions.SE:
                    shiftX = ++shiftX;
                    break;
                case Directions.W:
                case Directions.NW:
                case Directions.SW:
                    shiftX = --shiftX;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"nameof{ direction }");
            }

            int resultX = startPosition.X + shiftX;
            int resultY = startPosition.Y + shiftY;

            if (resultX > 0 || resultY < 0 || resultX > _cells.GetUpperBound(0) || resultY > _cells.GetUpperBound(1))
                return false; 

            Cell cellUnderTest = _cells[resultX, resultY];

            return cellUnderTest != null ? cellUnderTest.IsAlive : false;
        }
    }
}
