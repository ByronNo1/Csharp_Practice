using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_運算符
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //算術運算式:
            //優先順序1: *、/、%
            //優先順序2 : +、-
            //先看優先順序再由左而右，小括號可以改變執行順序。
            //關係運算子
            //==、>、<、>=、<=、!=
            //邏輯運算子
            //&&、||、
            //複合指定運運子
            //=、+=、-=、*=、/=、%=。
            //遞增 遞減 運算子
            //++、--
            //a++、++a、b++、++b

            int X1, X2, X3;
            int Y1, Y2, Y3;
            X1 = 10;
            X2 = 2;
            X3 = 4;

            Console.WriteLine("X1: {0},X2: {1},X3: {2}", X1, X2, X3);
            Y1 = X1 + X2;
            Y2 = X2 - X3;
            Console.WriteLine(" X1 + X2 :{0},X2 - X3 :{1}", Y1, Y2);

            Y1 = X1 * X2;
            Y2 = X1 / X3;
            Y3 = X1 % X3;

            Console.WriteLine("X1 * X2 : {0},X1 / X3 : {1},X1 % X3 : {2}", Y1, Y2, Y3);

            Y1 = X1 - X2 * X3;
            Console.WriteLine("X1 - X2 * X3 ==> {0}", Y1);

            Y1 = (X1 - X2) * X3;
            Console.WriteLine("(X1 - X2) * X3 ==> {0}", Y1);


            //關係運算子
            //==、>、<、>=、<=、!=

            Console.WriteLine("------------關係運算子-----------", X1, X2, X1 == X2);
            Console.WriteLine("{0} == {1} : {2}", X1, X2, X1 == X2);
            Console.WriteLine("{0} == {1} : {2}", X1, X1, X1 == X1);
            Console.WriteLine("{0} >  {1} : {2}", X1, X2, X1 > X1);
            Console.WriteLine("{0} <  {1} : {2}", X1, X2, X1 < X2);
            Console.WriteLine("{0} >= {1} : {2}", X1, X2, X1 >= X2);
            Console.WriteLine("{0} >= {1} : {2}", X1, X1, X1 >= X1);
            Console.WriteLine("{0} <= {1} : {2}", X1, X2, X1 <= X2);
            Console.WriteLine("{0} <= {1} : {2}", X1, X1, X1 <= X1);
            Console.WriteLine("{0} != {1} : {2}", X1, X2, X1 != X2);
            Console.WriteLine("{0} != {1} : {2}", X1, X1, X1 != X1);

            //邏輯運算子
            //&&、||
            bool IsTure = true;
            bool IsFalse = false;
            Console.WriteLine("------------邏輯運算子001---------------");
            if (IsTure)
            {
                Console.WriteLine("This is True");
            }
            else
            {
                Console.WriteLine("This is False");
            }
            Console.WriteLine("------------邏輯運算子002 : && ---------------");
            if (IsTure && IsFalse)
            {
                Console.WriteLine("This is True");
            }
            else
            {
                Console.WriteLine("This is False");
            }

            Console.WriteLine("------------邏輯運算子003 : || ---------------");
            if (IsTure || IsFalse)
            {
                Console.WriteLine("This is True");
            }
            else
            {
                Console.WriteLine("This is False");
            }


            Console.WriteLine("------------邏輯運算子004 : & ---------------");
            int i = 0;
            if (IsTure & GIsBool)
            {
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is True");
            }
            else
            {
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is False");
            }                                                      
            i++;                                                   
            if (IsTure && GIsBool)                                 
            {                                                      
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is True");
            }                                                      
            else                                                   
            {                                                      
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is False");
            }                                                      
            i++;                                                   
            if (IsFalse & GIsBool)                                 
            {                                                      
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is True");
            }                                                      
            else                                                   
            {                                                      
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is False");
            }                                                      
            i++;                                                   
            if (IsFalse && GIsBool)                                
            {                                                      
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is True");
            }                                                      
            else                                                   
            {                                                      
                Console.WriteLine(i.ToString().PadLeft(2, '0') + " This is False");
            }

            //複合指定運運子
            //=、+=、-=、*=、/=、%=。
            Console.WriteLine("------複合指定運運子---------");

            int n1;
            n1 = 1;
            Console.WriteLine("n1: {0}", n1);
            n1 += 10;
            Console.WriteLine("n1 += 10 : {0}", n1);
            n1 -= 5;
            Console.WriteLine("n1 -= 5 : {0}", n1);
            n1 *= 6;
            Console.WriteLine("n1 *= 6 : {0}", n1);
            n1 /= 3;
            Console.WriteLine("n1 /= 3 : {0}", n1);
            n1 %= 2;
            Console.WriteLine("n1 %= 2 : {0}", n1);

            //遞增 遞減 運算子
            //++、--
            //a++、++a、b++、++b
            Console.WriteLine("------遞增 遞減 運算子---------");
            n1 = 0;
            Console.WriteLine("n1: {0}", n1);
            n1++;
            Console.WriteLine("n1++: {0}", n1);
            ++n1;
            Console.WriteLine("++n1: {0}", n1);

            n1--;
            Console.WriteLine("n1--: {0}", n1);
            --n1;
            Console.WriteLine("--n1: {0}", n1);

            GintB = GintA++;
            Console.WriteLine(" GintA++: {0}", GintB);
            GintB = ++GintA;
            Console.WriteLine(" ++GintA: {0}", GintB);

            Console.WriteLine("");  
         
            Console.ReadKey();

        }

        private static bool _GIsBool = false;  //字段
        public static bool GIsBool     //屬性
        {
            get 
            {
                Console.WriteLine("GIsBool Running");
                return _GIsBool; 
            }
            set { _GIsBool = value; }
        }


        private static int _intA = 0;  //字段
        public static int GintA     //屬性
        {
            get
            {
                Console.WriteLine("GintA Get Running:" + _intA);
                return _intA;
            }
            set 
            {
                Console.WriteLine("GintA SET Running:" + value);
                _intA = value; 
            }
        }

        private static int _intB = 0;  //字段
        public static int GintB     //屬性
        {
            get
            {
                Console.WriteLine("GintB Get Running:" + _intB);
                return _intB;
            }
            set
            {
                Console.WriteLine("GintB SET Running:" + value);
                _intB = value;
            }
        }


    }




}
