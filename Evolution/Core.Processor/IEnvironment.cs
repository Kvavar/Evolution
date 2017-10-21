namespace Core.Processor
{
    interface IEnvironment
    {
        bool IsCellAlive(TwoDimPoint cellPosition);

        bool IsCellAlive(TwoDimPoint startPosition, Directions direction);

        bool IsHeaven(TwoDimPoint position);
    }
}
