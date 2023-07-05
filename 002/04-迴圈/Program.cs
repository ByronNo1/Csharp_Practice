using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_迴圈
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while (counter < 10)
            {
                counter++;
                Console.WriteLine("Hello World! The counter is {0}", counter);
                
            }

            Console.WriteLine("----------------------------------------------------------");
            counter = 0;
            do
            {
                counter++;
                Console.WriteLine("Hello World! The counter is {0}", counter);

            } while (counter < 10);
            Console.WriteLine("----------------------------------------------------------");

            counter = 0;
            while (counter < 0) //先判斷後執行
            {   //不會執行
                counter++; 
                Console.WriteLine("Hello World! The counter is {0}", counter);
            }
            Console.WriteLine("----------------------------------------------------------");


            counter = 0;
            do      //先執行後判斷
            {
                counter++;
                Console.WriteLine("Hello World! The counter is {0}", counter);

            } while (counter < 0);
            Console.WriteLine("----------------------------------------------------------");



            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine("Hello World! The index is {0}", index);
            }
            Console.WriteLine("----------------------------------------------------------");

            for (int index = 0; index < 10; index += 2)
            {
                Console.WriteLine("Hello World! The index is {0}", index);
            }
            Console.WriteLine("----------------------------------------------------------");

            for (int index = 0; index < 10 && index < 9 ; index += 3)
            {
                Console.WriteLine("Hello World! The index is {0}", index);
            }
            Console.WriteLine("----------------------------------------------------------");

            for (char column = 'a'; column < 'k'; column++)
            {
                Console.WriteLine("The column is {0}" , column);
            }
            Console.WriteLine("----------------------------------------------------------");

            string[] strings = new string[] { "一萬", "四萬", "七萬", "東風" };
            
            foreach (string _Str in strings)
            {
                Console.WriteLine("我聽的牌是: {0}", _Str);
            }
            
            Console.WriteLine("--------------------break--------------------------------------");

            counter = 0;
            while (true) 
            {   //不會執行
                counter++;
                //if (counter == 5)
                if (counter >= 5)
                {
                    Console.WriteLine("The counter is {0},Break", counter);
                    break;
                }
                //if (counter / 2 == 2)
                //{
                //    Console.WriteLine("The counter is {0},Break", counter);
                //    break;
                //}
                Console.WriteLine("Hello World! The counter is {0}", counter);
            }

            Console.WriteLine("--------------------Continue--------------------------------------");
            counter = 0;
            while (true)
            {   //不會執行
                counter++;
                if (counter >= 5)
                {
                    Console.WriteLine("The counter is {0},Break", counter);
                    break;
                }
                if (counter == 4)
                {
                    Console.WriteLine("The counter is {0},continue", counter);
                    counter += 100;
                    continue;
                }
                
                Console.WriteLine("Hello World! The counter is {0}", counter);
               


            }


            Console.ReadKey();


        }


    }
}
