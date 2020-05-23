using System.Collections.Generic;
using Evolution.Model;

namespace Evolution.Creator
{
    public interface ICreator
    {
        List<Creature> Create();
    }
}