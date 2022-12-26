using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab7
{
    public class MyThread
    {
        private int x;
        public MyThread(int x)
        {
            this.x = x;
        }
        public void ThreadMain()
        {
            int[] arr = new int[x];

            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(100);
            }

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            List<int> AnswLst = new List<int> { };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 3 == 0)
                    AnswLst.Add(arr[i]);
            }

            Console.WriteLine("Список элементов делящихся на 3:");
            foreach (int el in AnswLst)
            {
                Console.Write(el + " ");
            }

            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyThread(10);
            var t1 = new Thread(obj.ThreadMain);

            t1.Start();
            Console.ReadKey();
        }
    }
}
