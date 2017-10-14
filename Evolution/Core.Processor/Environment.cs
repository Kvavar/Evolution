using System;

namespace Core.Processor
{
    internal class Environment : IEnvironment
    {
        private Cell[,] _cells;

        public Environment(Cell[,] cells) => _cells = cells;

        public void AddOrRelaceCell(Cell cell)
        {
            _cells[cell.Position.X, cell.Position.Y] = cell;
        }

        public bool IsCellAlive(TwoDimPoint cellPosition)
        {
            Cell cellUnderTest = _cells[cellPosition.X, cellPosition.Y];

            return cellUnderTest != null ? cellUnderTest.IsAlive : false;
        }

        public bool IsCellAlive(TwoDimPoint startPosition , Directions direction)
        {
            int shiftX = 0;
            int shiftY = 0;

            switch (direction)
            {
                case Directions.N:
                    shiftY = --shiftY;
                    break;
                case Directions.NE:
                    shiftY = --shiftY;
                    shiftX = ++shiftX;
                    break;
                case Directions.E:
                    shiftX = ++shiftX;
                    break;
                case Directions.SE:
                    shiftY = ++shiftY;
                    shiftX = ++shiftX;
                    break;
                case Directions.S:
                    shiftY = ++shiftY;
                    break;
                case Directions.SW:
                    shiftY = ++shiftY;
                    shiftX = --shiftX;
                    break;
                case Directions.W:
                    shiftX = --shiftX;
                    break;
                case Directions.NW:
                    shiftY = --shiftY;
                    shiftX = --shiftX;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{nameof(direction)}");
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
