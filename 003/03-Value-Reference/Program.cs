using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_結構
{
    internal class Program
    {

        //Stack                                    Heap
        //S1 (int) 2                               H1
        //S2 (int) 5                               H2
        //S3 (int[]) H1                            H3
        //S4 (int[]) H2                            H4
        //S5                                       H5
        //S6                                       H6
        //S7                                       H7

        static void Main(string[] args)
        {
        
            unsafe
            {
                int X1 = 0;
                int X2 = 0;


                Console.WriteLine("X1的地址:" + ((long)&X1).ToString("X2"));
                Console.WriteLine("X2的地址:" + ((long)&X2).ToString("X2"));

                int X3 = X2;
                Console.WriteLine("X3的地址:" + ((long)&X3).ToString("X2"));


                int[] array1 = new int[] { 1, 3, 5, 7, 9 };
                //Console.WriteLine(&array1);
                fixed (int* pointerToFirst = array1)
                {
                    Console.WriteLine("array1 起始地址:" + ((long)pointerToFirst).ToString("X2"));
                    // The address stored in pointerToFirst
                    // is valid only inside this fixed statement block.
                }

                fixed (int* pointerToFirst = &array1[0])
                {
                    Console.WriteLine("array1[0] 地址:" + ((long)pointerToFirst).ToString("X2"));
                    // The address stored in pointerToFirst
                    // is valid only inside this fixed statement block.
                }
                fixed (int* pointerToFirst = &array1[1])
                {
                    Console.WriteLine("array1[1] 地址:" + ((long)pointerToFirst).ToString("X2"));
                    // The address stored in pointerToFirst
                    // is valid only inside this fixed statement block.
                }
                fixed (int* pointerToFirst = &array1[2])
                {
                    Console.WriteLine("array1[2] 地址:" + ((long)pointerToFirst).ToString("X2"));
                    // The address stored in pointerToFirst
                    // is valid only inside this fixed statement block.
                }

                Console.WriteLine("----------------指針使用-------------------");
                fixed (int* pointerToFirst = array1)
                {
                    Console.WriteLine("array1[0] 地址:" + ((long)pointerToFirst).ToString("X2"));
                    Console.WriteLine("array1[1] 地址:" + ((long)(pointerToFirst + 1)).ToString("X2"));

                    for (int i = 0; i < array1.Length; i++)
                    {
                        Console.WriteLine(pointerToFirst[i]);
                    }

                }


                Console.WriteLine("-----------------------------------");
                int[] array2 = array1;
                fixed (int* pointerToFirstB = array2)
                {
                    Console.WriteLine("array2 地址:" + ((long)pointerToFirstB).ToString("X2"));
                    // The address stored in pointerToFirst
                    // is valid only inside this fixed statement block.
                }

                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i] = 0;
                }
                for (int i = 0; i < array1.Length; i++)
                {
                    Console.WriteLine("array1-{0}:{1}" ,i, array1[i]);
                }

                for (int i = 0; i < array2.Length; i++)
                {
                    Console.WriteLine("array2-{0}:{1}", i, array2[i]);
                }
                Console.WriteLine("---------------array2 = new int[] --------------------");

                array2 = new int[] { 1, 3, 5, 7, 9 };
                fixed (int* pointerToFirst = array1)
                {
                    Console.WriteLine("array1 地址:" + ((long)pointerToFirst).ToString("X2"));
                }
                fixed (int* pointerToFirstB = array2)
                {
                    Console.WriteLine("array2 地址:" + ((long)pointerToFirstB).ToString("X2"));
                }


                Console.WriteLine("-----------------------------------");



                string Str1 = "ABC";
                string Str2 = "BBC";
                
                fixed (char* pointerToFirst = Str1)
                {
                    Console.WriteLine("Str1的地址:" + ((long)pointerToFirst).ToString("X2"));
                }
                fixed (char* pointerToFirst = Str2)
                {
                    Console.WriteLine("Str2的地址:" + ((long)pointerToFirst).ToString("X2"));
                }

                string Str3 = Str2;
                fixed (char* pointerToFirst = Str3)
                {
                    Console.WriteLine("Str3的地址:" + ((long)pointerToFirst).ToString("X2"));
                }

                Str2 = "CBC"; // Str2 = new string(new char[] { 'C','B','C'});
                fixed (char* pointerToFirst = Str2)
                {
                    Console.WriteLine("Str2:" + Str2);
                    Console.WriteLine("Str2的地址:" + ((long)pointerToFirst).ToString("X2"));
                }
                fixed (char* pointerToFirst = Str3)
                {
                    Console.WriteLine("Str3:" + Str3);
                    Console.WriteLine("Str3的地址:" + ((long)pointerToFirst).ToString("X2"));
                }

             


            } //unsafe




            Console.ReadKey();

        }



    }


}
