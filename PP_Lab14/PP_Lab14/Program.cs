using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int x = 3, y = 5, z = 2;
            int[,,] matrix = new int[y, x, z];
            Random random = new Random();
            Console.WriteLine("Initialization: ");
            ParallelLoopResult res = Parallel.For(0, x, j =>
            {
                for (int i = 0; i < y; i++)
                {
                    for (int t = 0; t < z; t++)
                    { 
                        matrix[i, j, t] = random.Next(1000);
                        Console.WriteLine("matrix [{0}, {1}, {2}] = {3} \t Thread: {4} \t Task {5}",
                        i, j, t, matrix[i, j, t],
                        Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                    }
                }
            });
            Console.WriteLine("Initialization finished - {0}\n", res.IsCompleted);
            int MinElofMass = matrix[0, 0, 0];
            res = Parallel.For(0, y, i =>
            {
                int Min = matrix[i, 0, 0];
                for (int j = 0; j < x; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (Min > matrix[i, j, k])
                            Min = matrix[i, j, k];
                    }
                }
                if (MinElofMass > Min)
                    MinElofMass = Min;
            });

            Console.WriteLine("Min in mass {0}", MinElofMass);

            Console.ReadLine();
        }
    }
}
