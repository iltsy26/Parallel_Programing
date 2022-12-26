using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input x value: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Input y value: ");
            int y = Convert.ToInt32(Console.ReadLine());
            int[,] mtrx = new int[x, y];

            Task tMtrxGen = new Task(
                () =>
                {
                    Console.WriteLine("Matrix generation. Start");
                    Random rnd = new Random();
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            mtrx[i, j] = rnd.Next(100) - 25;
                        }
                    }

                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            Console.Write(mtrx[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Matrix generation. Finish");
                });

            Task tSumOfElDivBy4 = tMtrxGen.ContinueWith(
                base_task =>
                {
                    Console.WriteLine("Matrix generation {0} finished.", base_task.Id);
                    Console.WriteLine("Calculation of the sum of elements divisible by 4. Start");

                    int SumOfElms = 0;
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            if(mtrx[i, j] % 4 == 0)
                                SumOfElms += mtrx[i, j];
                        }
                    }

                    Console.WriteLine("Sum of elements divisible by 4 is, {0}", SumOfElms);

                    Console.WriteLine("Calculation of the sum of elements divisible by 4. Finish");
                });
            Task tNumOfElDivBy3 = tSumOfElDivBy4.ContinueWith(
                base_task =>
                {
                    Console.WriteLine("tSumOfElDivBy4 {0} finished.", base_task.Id);
                    Console.WriteLine("Calculation of the number of elements divisible by 3. Start");

                    int NumOfElms = 0;
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            if (mtrx[i, j] % 3 == 0)
                                NumOfElms++;
                        }
                    }

                    Console.WriteLine("Number of elements divisible by 3 is, {0}", NumOfElms);

                    Console.WriteLine("Calculation of the number of elements divisible by 3. Finish");
                });
            Task tMinEl = tNumOfElDivBy3.ContinueWith(
                base_task =>
                {
                    Console.WriteLine("tNumOfElDivBy3 {0} finished.", base_task.Id);
                    Console.WriteLine("Mimimum element finding. Start");

                    int MinEl = mtrx[0, 0];
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            if (mtrx[i, j] <= MinEl)
                                MinEl = mtrx[i, j];
                        }
                    }

                    Console.WriteLine("Mimimum element is, {0}", MinEl);

                    Console.WriteLine("Mimimum element finding. Finish");
                });

            tMtrxGen.Start();

            Console.ReadLine();
        }
    }
}
