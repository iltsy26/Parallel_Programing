using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PP_Lab9
{
    public class VectorsProd
    {
        private int objId;
        private int x;
        private int[] vctr1;
        private int[] vctr2;

        public VectorsProd()
        {
            ObjId = objId;
            Vctr1 = new int[X];
            vctr2 = new int[X];
        }

        public int[] Vctr1 { get => vctr1; set => vctr1 = value; }
        public int[] Vctr2 { get => vctr2; set => vctr2 = value; }
        public int X { get => x; set => x = value; }
        public int ObjId { get => objId; set => objId = value; }

        public int[] InitializeVector()
        {
            DateTime NowDT = DateTime.Now;
            Random random = new Random((int)NowDT.Ticks);
            int[] Vctr = new int[X];
            for (int i = 0; i < Vctr.GetLength(0); ++i)
            {
                Vctr[i] = random.Next(100) - 50;
            }
            Thread.Sleep(300);

            return Vctr;
        }

        public int MultiOfVctrs(int[] Vctr1, int[] Vctr2)
        {
            int MultVctr = 0;

            for (int i = 0; i < Vctr1.GetLength(0); ++i)
                MultVctr += Vctr1[i] * Vctr2[i];

            return MultVctr;
        }

        public string VctrToString(int[] vctr)
        {
            string Vstr = "";

            for (int i = 0; i < vctr.Length; ++i)
            {
                Vstr += vctr[i] + " ";
            }

            return Vstr;
        }
    }

    public class VMassData
    {
        private List<VectorsProd> VMass;

        public VMassData ()
        {
            VMass = new List<VectorsProd>(2);
        }

        public void Add(VectorsProd newElement)
        {
            VMass.Add(newElement);

            ThreadPool.QueueUserWorkItem(VPMethod, newElement);
        }

        protected static void VPMethod(object state)
        {
            VectorsProd item = (VectorsProd)state;
            int[] v1 = item.Vctr1;
            int[] v2 = item.Vctr2;

            v1 = item.InitializeVector();
            string vStr1 = item.VctrToString(v1);
            Console.WriteLine("Thread {0}. Object {1}. Vector 1 initialization. Vector1: {2}",
                    Thread.CurrentThread.ManagedThreadId, item.ObjId, vStr1);

            v2 = item.InitializeVector();
            string vStr2 = item.VctrToString(v2);
            Console.WriteLine("Thread {0}. Object {1}. Vector 2 initialization. Vector2: {2}",
                    Thread.CurrentThread.ManagedThreadId, item.ObjId, vStr2);

            Console.WriteLine("Thread {0}. Object {1}. Vectors production complete. Scalar Product: {2}",
                    Thread.CurrentThread.ManagedThreadId, item.ObjId, item.MultiOfVctrs(v1, v2));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            int MaxWorkThread;
            int MaxIOThread;
            ThreadPool.GetMaxThreads(out MaxWorkThread, out MaxIOThread);
            Console.WriteLine("Max number of working threads: {0}." +
                "Max number of IO threads: {1}",
                MaxWorkThread, MaxIOThread);

            VMassData myData = new VMassData();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                myData.Add(new VectorsProd() {X = 2, ObjId = i + 1});
            }

            Console.Read();
        }
    }
}
