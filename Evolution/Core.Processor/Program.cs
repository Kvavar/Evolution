using System;

namespace Core.Processor
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell[,] cells = new Cell[10, 10];

            Environment env = new Environment(cells);

            LiveConditionsFactory factory = new LiveConditionsFactory();


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Cell neighbor = new Cell(env, new TwoDimPoint(i, j), factory.Create(LiveConditionsTypes.Simple));

                    env.AddOrRelaceCell(neighbor);
                }
            }

            Console.WriteLine(env.IsCellAlive(new TwoDimPoint(1, 1)));

            Console.ReadLine();
        }
    }
}
