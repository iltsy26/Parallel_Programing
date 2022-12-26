using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab8
{
    public class MyThread
    {
        private int data;
        public MyThread(int data)
        {
            this.data = data;  
        }

        public void ThreadMain()
        {
            Console.WriteLine("TF Speed array creation...");
            double[] SpeedArr = new double[data];

            Console.WriteLine();

            Console.WriteLine("TF Density array creation...");
            double[] DensityArr = new double[data];

            Console.WriteLine();

            Console.WriteLine("Initialization of arrays...");
            Random rnd = new Random();
            for (int i = 0; i < data; i++)
            {
                SpeedArr[i] = rnd.Next(1000);
                DensityArr[i] = rnd.Next(1000);
            }

            Console.WriteLine();

            Console.WriteLine("Speed array printing...");
            for (int i = 0; i < data; i++)
            {
                Console.Write(SpeedArr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Density array printing...");
            for (int i = 0; i < data; i++)
            {
                Console.Write(DensityArr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Intensity array calculation...");
            double[] IntensityArr = new double[data];
            for (int i = 0; i < data; i++)
            {
                IntensityArr[i] = SpeedArr[i] * DensityArr[i];
            }

            Console.WriteLine();

            Console.WriteLine("Intensity array printing...");
            for (int i = 0; i < data; i++)
            {
                Console.Write(IntensityArr[i] + " ");
            }
        }
    }

    internal class Program
    {

        public static void Main()
        {
            var obj = new MyThread(20);
            var t1 = new Thread(obj.ThreadMain);

            t1.Start();

            Console.ReadLine();
        }
    }
}
