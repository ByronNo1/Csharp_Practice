using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hello(); //() method
            CaculateA(5, 8);
            Console.WriteLine(returnA(8) + ";Type:" + returnA(8).GetType());
            Console.WriteLine(returnB(8));
            CaculateB(2);

            Console.WriteLine("------------------------------------");
            int X1, X2, X3;
            X1 = 2; X2 = 3; X3 = 4;
            Console.WriteLine("input>>> X1:{0},X2:{1},X3:{2}", X1, X2, X3);
            CaculateC(X1, X2, X3); // CaculateC(2, 3, 4); 
            Console.WriteLine("input>>> X1:{0},X2:{1}", X1, X2, X3);
            CaculateC(X1, X2);   // CaculateC(2, 3); 
            Console.WriteLine("input>>> X1:{0},X3:{2}", X1, X2, X3);
            CaculateC(X1, c: X3); // CaculateC(2, c:4); 
            Console.WriteLine("--------------Reference----------------------");
            int A = 9;
            Console.WriteLine("input>>> A:{0}", A );
            CaculateRef(ref A);
            Console.WriteLine("Output>>> A:{0}", A);
            unsafe
            {
                int B = 9;
                int* p = (int*)&B;

                Console.WriteLine("input>>> B:{0}", B);
                Console.WriteLine("input 地址>>> B:{0:X2}", (long)p);
                CaculateRef(ref B);
                Console.WriteLine("Output>>> A:{0}", B);
                Console.WriteLine("Output 地址>>> B:{0:X2}", (long)&B);

            }
            Console.WriteLine("------------------------------------------");
            int C = 55;
            Console.WriteLine("input>>> C:{0}", C);
            CaculateOut(out C);
            Console.WriteLine("Output>>> C:{0}", C);
            unsafe
            {
                C = 66;
                Console.WriteLine("input>>> C:{0}", C);
                Console.WriteLine("input 地址>>> C:{0:X2}", (long)&C);
                CaculateOut(out C);
                Console.WriteLine("Output>>> C:{0}", C);
                Console.WriteLine("Output 地址>>> C:{0:X2}", (long)&C);

                
                Console.WriteLine("input>>>  NO input");
                CaculateOut(out int d);
                Console.WriteLine("Output>>> d:{0}", d);
                Console.WriteLine("Output 地址>>> d:{0:X2}", (long)&d);

                int E;
                //Console.WriteLine("input>>> E:{0}", E);
                Console.WriteLine("input 地址>>> E:{0:X2}", (long)&E);
                CaculateOut(out E);
                Console.WriteLine("Output>>> E:{0}", E);
                Console.WriteLine("Output 地址>>> E:{0:X2}", (long)&E);
            }


            CaculateOut(out _); //新的Framework 才有
                                // CaculateRef(ref _); //ERROR


            Console.WriteLine("------------------------------------------");
            string T1 = "ABC";
            StrRef(ref T1);
            T1 = "ABC";
            StrOut(out T1);
            Console.WriteLine("------------------------------------------");
            Overloading(1);
            Overloading("Str1");
            Overloading("Str2", 2);

            
         
            Console.ReadKey();
        }

        static void StrRef(ref string _str)
        {
            string _str2 = _str; 
            _str = _str2 + ",REF";
        }

        static void StrOut(out string _str)
        {
            //string _str2 = _str; //有錯誤
            _str = "";
            _str += ",Out";
        }


        // void 
        static void Hello()
        {
            Console.WriteLine("Hello World");
        }

        // void 代參數
        static void CaculateA(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static int returnA(int x)
        {
            
            return x * 3;
        }

        //return
        static int returnB(int x)
        {
            if (x == 1)
            {
                return 1;
            }
            return x * returnB(x - 1);
        }

        //預設值
        static void CaculateB(int a, int b = 10)
        {
            Console.WriteLine("a:{0},b:{1} => a+b", a, b);
            Console.WriteLine(a * b); //印出結果
        }
        //利用冒號指定參數傳遞對象
        //指定  b:2  a:4
        //Caculate(b: 2, a: 4);
        static void CaculateC(int a, int b = 10,int c = 20)
        {
            Console.WriteLine("a:{0},b:{1},c:{2} => a+b+c", a, b, c);
            Console.WriteLine(a + b + c); //印出結果
        }

        // Reference
        static void CaculateRef(ref int a)
        {
            unsafe
            {
                fixed (int* intPtr = &a)
                {
                    Console.WriteLine("Ref inside:{0:X2}", (long)&intPtr);
                }
            }
           
            Console.WriteLine("input * 3"); //印出結果
            a = a * 3;
        }

        //out
        static void CaculateOut(out int a)
        {
            unsafe
            {
                fixed (int* intPtr = &a)
                {
                    Console.WriteLine("Out inside:{0:X2}", (long)&intPtr);
                }
            }
            //a在剛傳遞過來時，未賦予值
            //所以，如果寫成  a=a*3; 就會發生錯誤
            a = 33;
        }

        //Overloading 多載
        static void Overloading(int x)
        {
            Console.WriteLine("Phone Number is:" + x);
        }

        static void Overloading(string _str)
        {
            Console.WriteLine("Your name is :" + _str);
        }

        static void Overloading(string x, int y)
        {
            Console.WriteLine("Sexual: " + x + ", Height:" + y + " cm");
        }

    }

}
