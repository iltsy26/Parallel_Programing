using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action method = MtrxTransform;
            Thread[] tmas = new Thread[4];
            for(int i = 0; i < tmas.Length; i++)
            {
                tmas[i] = new Thread(MtrxTransform);
                tmas[i].Start();
            }

            Console.ReadKey();
        }

        static void CalcMax()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("Thread {0}. Massive creation...", threadId);
            int N = 20;
            int[] mas = new int[N];

            Console.WriteLine("Thread {0}. Initialization of massive elements...", threadId);
            Random rnd = new Random(threadId);
            for(int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(1000);
            }

            Console.WriteLine("Thread {0}. Max element searching...", threadId);
            int max = mas[0];
            for(int j = 1; j < mas.Length; j++)
            {
                max = (mas[j] > max) ? mas[j] : max;
            }

            Console.WriteLine("Thread {0}. Max element = {1}", threadId, max);
        }

        static void MtrxTransform()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("Thread {0}. Matrix creation...", threadId);
            int x = 4, y = 3;
            double[,] mtrx = new double[x, y];

            Console.WriteLine("Thread {0}. Initialization of matrix...", threadId);
            Random rnd = new Random(threadId);
            Console.WriteLine(mtrx.GetLength(0));
            Console.WriteLine(mtrx.GetLength(1));

            for (int i = 0; i < mtrx.GetLength(0); i++)
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    mtrx[i, j] = rnd.Next(1000);
                }
            }

            Console.WriteLine("Thread {0}. Matrix printing...", threadId);
            for (int i = 0; i < mtrx.GetLength(0); i++)
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    Console.Write(mtrx[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Thread {0}. Matrix transformation...", threadId);
            for (int i = 0; i < mtrx.GetLength(0); i++)
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    mtrx[i, j] = Math.Sin(mtrx[i, j]);
                } 

            Console.WriteLine("Thread {0}. Transformed matrix print...", threadId);
            for (int i = 0; i < mtrx.GetLength(0); i++)
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    Console.Write(mtrx[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
