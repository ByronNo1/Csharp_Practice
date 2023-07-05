using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_隨機數
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random _Random = new Random();
            //while (true)
            //{

            //    int iInt = _Random.Next(1, 11);
            //    Console.WriteLine(iInt);
            //    if (iInt == 7)
            //    {
            //        Console.WriteLine(iInt + " = 7 ,break");
            //        break;
            //    }
            //    //Console.ReadKey();
            //}
            

            Random _RandomA = new Random(2);
            Random _RandomB = new Random(2);
            Random _RandomC = new Random(7);
            while (true)
            {

                int iInt = _RandomA.Next(1, 11);
                Console.WriteLine("A:" + iInt);
                iInt =  _RandomB.Next(1, 11);
                Console.WriteLine("B:" + iInt);
                iInt = _RandomC.Next(1, 11);
                Console.WriteLine("C:" + iInt);
                Console.WriteLine("------------------------------------");
                //Console.ReadKey();
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    Console.WriteLine(@"離開");
                    break;
                }

            }


            Console.WriteLine(@"按下任意鍵離開");
            Console.ReadKey();



        }

    }

}
