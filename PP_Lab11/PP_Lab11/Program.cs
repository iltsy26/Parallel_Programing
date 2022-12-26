using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            
            Task t1 = new Task(ArithmMean);
            t1.Start();

            TaskFactory tf = new TaskFactory();
            Task t2 = tf.StartNew(ArithmMean);

            Task t3 = Task.Factory.StartNew(ArithmMean);

            Console.ReadKey();
        }

        private static void ArithmMean ()
        {
            int x = 1, y = 2, z = 4;
            int[,,] mass = new int[x, y, z];
            Random rand = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        mass[i, j, k] = rand.Next(100);
                    }
                }
            }

            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("x= " + i);
                for (int j = 0; j < y; j++)
                {
                    Console.WriteLine("y= " + j);
                    for (int k = 0; k < z; k++)
                    {
                        Console.Write(mass[i, j, k] + " ");
                    }
                    Console.WriteLine();    
                }
            }

            int arithMeanVal = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        arithMeanVal += mass[i, j, k];
                    }
                }
            }
            arithMeanVal /= (x * y * z);

            Console.WriteLine("Arithmetic mean of the mass = {0}", arithMeanVal);

        }
    }
}
