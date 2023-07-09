using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 靜態
{
    internal class HOUSE
    {
       public int money ;
       public string address ;
       public int floor;

    }

    internal static class HOUSE_2
    {
        public static int money;
        public static string address;
        public static int floor;

    }


    internal static class ADD
    {
        public static int X;
        public static int Y;

        public static void ADD1()
        {
            Console.WriteLine(X + Y);
        }
        public static int S1(int _X,int _Y)
        {
            Console.WriteLine(_X + " * " + _Y + " = ");
            return _X * _Y;
        }
    }

    //internal static class HOUSE_3 : HOUSE_2
    //{
    //    //public static int money;
    //    //public static string address;
    //    //public static int floor;

    //}


}
