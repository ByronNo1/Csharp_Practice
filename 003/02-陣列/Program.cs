using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_陣列
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int X1 = 1;
            int X2 = 3;
            int X3 = 5;
            int X4 = 7;
            int X5 = 9;

            Console.WriteLine(X1);
            Console.WriteLine(X2);
            Console.WriteLine(X3);
            Console.WriteLine(X4);
            Console.WriteLine(X5);

            Console.WriteLine("-----------------陣列 array1-------------------");
            int[] array1 = new int[] { 1, 3, 5, 7, 9 };
            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine(Convert.ToString(array1[i]));
            }

            Console.WriteLine("-----------------陣列 array weekDays-------------------");
            string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < weekDays.Length; i++)
            {
                Console.WriteLine(Convert.ToString(weekDays[i]));
            }


            int[] array2 = { 1, 3, 5, 7, 9 };
            string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            int[] array3;
            array3 = new int[] { 1, 3, 5, 7, 9 };   // OK
            //array3 = {1, 3, 5, 7, 9};   // Error

            int[] array4 ;
            array4 = new int[1];

            Console.WriteLine("-----------------陣列 array4 A -------------------");
            for (int i = 0; i < array4.Length; i++)
            {
                array4[i] = 0;
                Console.WriteLine("array4:" + Convert.ToString(array4[i]));
            }

            Console.WriteLine("-----------------陣列 array4 B -------------------");
            array4 = new int[8];
            for (int i = 0; i < array4.Length; i++)
            {
                array4[i] = i;
                Console.WriteLine("array4 B:" + Convert.ToString(array4[i]));
            }


           

            Console.ReadKey();

        }

    }

}
