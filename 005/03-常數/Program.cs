using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_常數
{
    internal class Program
    {
        const int X_01= 100;
        const int X_02= 101;
        const int X_03= 102;
        const int X_04= 103;
        public const double Pi = 3.14159;


        static void Main(string[] args)
        {

            Console.WriteLine("1:" + X_01);
            Console.WriteLine("2:" + X_02);
            Console.WriteLine("3:" + X_03);
            Console.WriteLine("4:" + X_04);


            Console.WriteLine("Area :" + 4 * 4 * Pi);

            Console.ReadKey();
        }

    }
}
