using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab2
{
    internal class Program
    {

        static Random random = new Random();

        static int[] InitializeVector(int x)
        {
            int[] Vctr = new int[x];
            for (int i = 0; i < Vctr.GetLength(0); ++i)
            {
                Vctr[i] = random.Next(100) - 50;
            }
            return Vctr;
        }

        static int MultiOfVctrs(int[] Vctr1, int[] Vctr2)
        {
            int MultVctr = 0;

            for (int i = 0; i < Vctr1.GetLength(0); ++i)
                MultVctr += Vctr1[i] * Vctr2[i];

            return MultVctr;
        }

        static void Print(int[] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                Console.Write("{0,5}", array[i]);
            }
            Console.WriteLine();
        }

        public delegate int VcrtMultiDelegate(int x, int ms);

        public static int VctrMultiMethod(int x, int ms)
        {
            Console.WriteLine("Multiply Method started");

            int[] Vctr1 = InitializeVector(x);
            int[] Vctr2 = InitializeVector(x);
            int MutliVctr = MultiOfVctrs(Vctr1, Vctr2);

            Print(Vctr1);
            Console.WriteLine();

            Thread.Sleep(ms);

            Console.WriteLine();
            Print(Vctr2);

            Console.WriteLine();

            Console.WriteLine("Multiply Method finished");

            return MutliVctr;

        }

        private static void Main(string[] args)
        {
            Console.Write("Введите размерность x исходных векторов: ");
            int x = Convert.ToInt32(Console.ReadLine());

            VcrtMultiDelegate VctrDl = VctrMultiMethod;

            IAsyncResult ar = VctrDl.BeginInvoke(x, 3000, null, null);
            while (!ar.IsCompleted)
            {
                Console.Write('.');
                Thread.Sleep(100);
            }
            int result = VctrDl.EndInvoke(ar);

            Console.WriteLine("result: {0}", result);

            Console.ReadKey();
        }
    }
}
