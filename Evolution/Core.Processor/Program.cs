using System;
using System.Text;
using System.Threading;

namespace Core.Processor
{
    class Program
    {
        private static int amountX = 50;
        private static int amountY = 75;

        static void Main(string[] args)
        {
            Cell[,] cells = new Cell[amountX, amountY];

            Environment env = new Environment(cells);

            LiveConditionsFactory factory = new LiveConditionsFactory();

            Random rand = new Random();//write an own random generator

            for (int i = 0; i < amountX; i++)
            {
                for (int j = 0; j < amountY; j++)
                {
                    Cell neighbor = new Cell(env, new TwoDimPoint(i, j), factory.Create(LiveConditionsTypes.Simple));

                    int random = rand.Next();

                    neighbor.State = random % 6 == 0 && i < 10 && j < 10 ? CellStates.Alive : CellStates.Dead;

                    env.AddOrReplaceCell(neighbor);
                }
            }

            while(true)
            {
                for (int i = 0; i < amountX; i++)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int j = 0; j < amountY; j++)
                    {
                        sb.Append(env.IsCellAlive(cells[i, j].Position) ? 1 : 0);
                    }

                    Console.WriteLine(sb.ToString());
                }

                for (int i = 0; i < amountX; i++)
                {
                    for (int j = 0; j < amountY; j++)
                    {
                        cells[i, j].UpdateState();
                    }
                }

                Thread.Sleep(1500);

                Console.Clear();
            }

            Console.ReadLine();
        }
    }
}
