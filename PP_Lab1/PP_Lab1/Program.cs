using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Action<Func<int, int>, List<string>> l = (par1, par2) =>
            //{


            //};

            Action<Func<int, int>, List<string>> action_1 = writeMessage;
            Func<int, int> thirdDegree = func1;

            List<string> testList = new List<string> { " меньше или равно 0", " больше 0, но меньше или равно 100",
                                                    " больше 100, но меньше или равно 300", " больше 300, но меньше или равно 500",
                                                    " больше 500, но меньше или равно 1000", " больше 1000" };

            action_1(thirdDegree, testList);

            Console.ReadKey();

        }

        private static int func1(int x)
        {
            int res = (int)Math.Pow(x, 3);
            return res;
        }

        private static void writeMessage(Func<int, int> s1, List<string> lst)
        {

            int inpt = Convert.ToInt32(Console.ReadLine());
            int x = s1(inpt);
            string str = "число: ";
            if (x <= 0)
                Console.WriteLine(str + x + lst[0]);
            else if (0 < x && x <= 100)
                Console.WriteLine(str + x + lst[1]);
            else if (100 < x && x <= 300)
                Console.WriteLine(str + x + lst[2]);
            else if (300 < x && x <= 500)
                Console.WriteLine(str + x + lst[3]);
            else if (500 < x && x <= 1000)
                Console.WriteLine(str + x + lst[4]);
            else if (x > 1000)
                Console.WriteLine(str + x + lst[5]);
        }

    }
}
