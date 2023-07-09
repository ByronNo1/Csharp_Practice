using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _04_委派
{
    internal class Program
    {
        public delegate void Calculate(int t1, int t2);
        public delegate void Del(string message);

        static void Main(string[] args)
        {
            Del handler = DelegateMethod;

            // Call the delegate.
            handler("Hello World");


            Calculate Calculate1;
            Calculate Calculate2;
            Calculate1 = ADD;
            Calculate1(5, 3);

            Calculate1 = Subtract;
            Calculate1(5, 3);


            CalculateFuncion(10, 20, ADD);
            CalculateFuncion(10, 110, Subtract);






            X1 = 10;
            Console.WriteLine("Main X1:"  + X1 );

            eventhandler += handler;
            X1 = 20;

            Console.WriteLine("-----------------30------------------");
            eventhandler += handler;
            X1 = 30;

            Console.WriteLine("-----------------40------------------");
            eventhandler -= handler;
            X1 = 40;
            Console.WriteLine("-----------------50------------------");
            eventhandler -= handler;
            eventhandler -= handler;
            X1 = 50;

         
            Console.ReadKey();
        }

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
        public static void ADD(int t1, int t2)
        {
            Console.WriteLine(t1 + t2);
        }

        public static void Subtract(int t1, int t2)
        {
            Console.WriteLine(t1 - t2);
        }

        public static void CalculateFuncion(int t1, int t2, Calculate _Calculate)
        {
            _Calculate(t1 , t2);
        }



        public static event Del eventhandler;

        static int _X1 = 0;
        public static int X1
        {
            get 
            {
                return _X1; 
            }
            set 
            {
                if (eventhandler != null)
                {
                    eventhandler("X1 eventhandler : "  + value.ToString());
                }
                else
                {
                    Console.WriteLine("X1 eventhandler : Null");
                };
                _X1 = value; 
            }
        }

    }

}
