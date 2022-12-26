using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab4
{
    internal class Program
    {

        static Random random = new Random();

        public delegate int TakesAWhileDelegate(int data, int ms, int[,] Mtrx);

        static int TakesAWhile(int data, int ms, int[,] Mtrx)
        {
            Console.WriteLine("DiffSearch() started at the {0} thread", Thread.CurrentThread.GetHashCode());

            int diffResult = DiffSearch(Mtrx);
            Thread.Sleep(ms);

            Console.WriteLine("DiffSearch() finished");
            Console.WriteLine("result: {0}", diffResult);
            return ++data;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main() started at the {0} thread", Thread.CurrentThread.GetHashCode());

            int x = 4, y = 4;

            int[,] Mtrx = InitializeMtrx(x, y);

            Console.WriteLine();

            PrintMtrx(Mtrx);

            TakesAWhileDelegate dl = new TakesAWhileDelegate(TakesAWhile);

            IAsyncResult ar = dl.BeginInvoke(10, 5000, Mtrx, new AsyncCallback(TakesAWhileCompleted), null);

            Console.Read();
        }

        static void TakesAWhileCompleted(IAsyncResult ar)
        {
            Console.WriteLine("All calculations are finished");
        }

        static int[,] InitializeMtrx(int x, int y)
        {
            int[,] Mtrx = new int[x, y];
            for (int i = 0; i < Mtrx.GetLength(0); ++i)
                for (int j = 0; j < Mtrx.GetLength(1); ++j)
                {
                    Mtrx[i, j] = random.Next(100) - 50;
                }
            return Mtrx;
        }

        static void PrintMtrx(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                    Console.Write("{0,5}", array[i, j]);
                Console.WriteLine();
            }
        }

        static int DiffSearch(int[,] Mtrx)
        {
            int maxEl = Mtrx[0, 0], minEl = Mtrx[0, 0], diff;

            for (int i = 0; i < Mtrx.GetLength(0); ++i)
                for (int j = 0; j < Mtrx.GetLength(1); ++j)
                {
                    if (Mtrx[i, j] > maxEl)
                        maxEl = Mtrx[i, j];
                    if (Mtrx[i, j] < minEl)
                        minEl = Mtrx[i, j];
                }

            Console.WriteLine("max: {0}", maxEl);
            Console.WriteLine("min: {0}", minEl);
            diff = maxEl - minEl;

            return diff;
        }
    }
}
