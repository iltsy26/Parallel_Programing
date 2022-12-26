using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action method = TFIntensity;
            Thread[] tmas = new Thread[1];
            for (int i = 0; i < tmas.Length; i++)
            {
                tmas[i] = new Thread(TFIntensity);
                tmas[i].Start();
            }

            Console.ReadKey();
        }

        static void TFIntensity()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            int x = 30;

            Console.WriteLine("Thread {0}. TF Speed array creation...", threadId);
            double[] SpeedArr = new double[x];

            Console.WriteLine();

            Console.WriteLine("Thread {0}. TF Density array creation...", threadId);
            double[] DensityArr = new double[x];

            Console.WriteLine();

            Console.WriteLine("Thread {0}. Initialization of arrays...", threadId);
            Random rnd = new Random(threadId);
            for (int i = 0; i < x; i++)
            {
                SpeedArr[i] = rnd.Next(1000);
                DensityArr[i] = rnd.Next(1000);    
            }

            Console.WriteLine();

            Console.WriteLine("Thread {0}. Speed array printing...", threadId);
            for (int i = 0; i < x; i++)
            {
                    Console.Write(SpeedArr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Thread {0}. Density array printing...", threadId);
            for (int i = 0; i < x; i++)
            {
                Console.Write(DensityArr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Thread {0}. Intensity array calculation...", threadId);
            double[] IntensityArr = new double[x];
            for (int i = 0; i < x; i++)
            {
                IntensityArr[i] = SpeedArr[i] * DensityArr[i];
            }

            Console.WriteLine();

            Console.WriteLine("Thread {0}. Intensity array printing...", threadId);
            for (int i = 0; i < x; i++)
            {
                Console.Write(IntensityArr[i] + " ");
            }
        }
    }
}
