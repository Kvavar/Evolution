using System.Collections.Generic;
using Evolution.Model;

namespace Evolution.Factor
{
    public interface ISelection
    {
        List<Creature> Select(List<Creature> creatures);
    }
}