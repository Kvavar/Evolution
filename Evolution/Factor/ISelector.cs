using Evolution.Model;

namespace Evolution.Factor
{
    public interface ISelector
    {
        bool Examine(Creature creature);
        SelectorType Type { get; }
    }
}