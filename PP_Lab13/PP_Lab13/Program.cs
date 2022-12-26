using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab13
{
    public class TaskResult
    {
        public int[,] mas;

        public int tSumOfElDivBy4 { get
            {
                int SumOfElms = 0;
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        if (mas[i, j] % 4 == 0)
                            SumOfElms += mas[i, j];
                    }
                }

                return SumOfElms;
            } 
        }

        public int tNumOfElDivBy3
        {
            get
            {
                int NumOfElms = 0;
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        if (mas[i, j] % 3 == 0)
                            NumOfElms++;
                    }
                }

                return NumOfElms;
            }
        }

        public int tMinEl
        {
            get
            {
                int MinEl = mas[0, 0];
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        if (mas[i, j] <= MinEl)
                            MinEl = mas[i, j];
                    }
                }

                return MinEl;
            }
        }
    }

    internal class Program
    {
        public static TaskResult MethodForTask(object dim)
        {
            TaskResult result = new TaskResult();
            int dimCount = (int)dim;

            result.mas = new int[dimCount, dimCount];
            Random rand = new Random();
            for (int i = 0; i < dimCount; i++)
            {
                for (int j = 0; j < dimCount; j++)
                {
                    result.mas[i, j] = rand.Next(1000) - 200;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var TaskWithResult = new Task<TaskResult>(MethodForTask, 4);
            TaskWithResult.Start();
            int[,] mas = TaskWithResult.Result.mas;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Sum of elements divisible by 4 = {0} " +
                "\nNumber of elements divisible by 3 = {1} " +
                "\nMimimum element = {2} ",
                TaskWithResult.Result.tSumOfElDivBy4, 
                TaskWithResult.Result.tNumOfElDivBy3, 
                TaskWithResult.Result.tMinEl);
            Console.ReadKey();
        }
    }
}
