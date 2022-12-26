using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab10
{
    public class TFModel
    {
        private int objId;
        private int x;
        private double[] speedArr;
        private double[] densityArr;

        public TFModel()
        {
            ObjId = objId;
            SpeedArr = new double[X];
            DensityArr = new double[X];
        }

        public int X { get => x; set => x = value; }
        public int ObjId { get => objId; set => objId = value; }
        public double[] SpeedArr { get => speedArr; set => speedArr = value; }
        public double[] DensityArr { get => densityArr; set => densityArr = value; }

        public double[] InitializeVector()
        {
            DateTime NowDT = DateTime.Now;
            Random random = new Random((int)NowDT.Ticks);
            double[] Vctr = new double[X];
            for (int i = 0; i < Vctr.GetLength(0); ++i)
            {
                Vctr[i] = random.Next(500);
            }
            Thread.Sleep(300);

            return Vctr;
        }

        public double[] IntensityArrCalc(double[] sArr, double[] dArr)
        {
            double[] IntensityArr = new double[x];
            for (int i = 0; i < x; i++)
            {
                IntensityArr[i] = sArr[i] * dArr[i];
            }

            return IntensityArr;
        }

        public string VctrToString(double[] vctr)
        {
            string Vstr = "";

            for (int i = 0; i < vctr.Length; ++i)
            {
                Vstr += vctr[i] + " ";
            }

            return Vstr;
        }
    }

    public class TFMass
    {
        private List<TFModel> TFList;

        public TFMass()
        {
            TFList = new List<TFModel>(200);
        }

        public void Add(TFModel newElement)
        {
            TFList.Add(newElement);

            ThreadPool.QueueUserWorkItem(TFCalcMethod, newElement);
        }

        protected static void TFCalcMethod(object state)
        {
            TFModel item = (TFModel)state;
            double[] arrS = item.SpeedArr;
            double[] arrD = item.DensityArr;

            arrS = item.InitializeVector();
            string arrStr1 = item.VctrToString(arrS);
            Console.WriteLine("Thread {0}. Object {1}. Speed array initialization. Array: {2}",
                    Thread.CurrentThread.ManagedThreadId, item.ObjId, arrStr1);

            arrD = item.InitializeVector();
            string arrStr2 = item.VctrToString(arrD);
            Console.WriteLine("Thread {0}. Object {1}. Density array initialization. Array: {2}",
                    Thread.CurrentThread.ManagedThreadId, item.ObjId, arrStr2);

            double[] arrI = item.IntensityArrCalc(arrS, arrD);
            string arrStr3 = item.VctrToString(arrI);
            Console.WriteLine("Thread {0}. Object {1}. Intesity array calculation complete. Array: {2}",
                    Thread.CurrentThread.ManagedThreadId, item.ObjId, arrStr3);
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

            TFMass myData = new TFMass();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                myData.Add(new TFModel() { X = 10, ObjId = i + 1 });
            }

            Console.Read();
        }
    }
}
