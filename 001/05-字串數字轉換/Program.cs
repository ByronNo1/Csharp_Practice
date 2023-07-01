using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_字串數字轉換
{
    internal class Program
    {
        static void Main(string[] args)
        {  // 資料型別     範圍                              占用記憶體
           // bool         True/ false                       1 Byte
           // sbyte        -128~127                          1 Byte
           // byte         0~255                             1 Byte
           // short        -32768~32767                      2 Bytes(有負號)
           // ushort       0~65535                           2 Bytes(無負號)
           // int          -2147483648~2147483647            4 Bytes(有負號)
           // uint         0~4294967295                      4 Bytes(無負號)
           // long         -9223372036854775808~             
           // 			    9223372036854775807               8 Bytes(有負號)

            // ulong        0~18446744073709551615            8 Bytes(無負號)
            // float        -3.402823e38~3.402823e38          8 Bytes
            // double       -1.79769313486232e308             
            // 			    ~1.79769313486232e308             4 Bytes

            // decimal      -79228162514264337593543950335~   
            // 			    79228162514264337593543950335     16 Bytes

            // char                                           2 Bytes
            // String                                         變動長度(字元的陣列)

            //數字互相轉換
            byte byteA;
            short shortA;
            int intA;
            double doubleA;
            float floatA;
            //-----byte--------
            byteA = 55;
            Console.WriteLine("A01-byteA:" + byteA);
           // byteA = 256; //會錯誤
            Console.WriteLine("A02-byteA:" + byteA);


            //字串轉數字
            string _Str;
            _Str = "987.321";

            int iInt;
            _Str = "987";
            iInt = Convert.ToInt16(_Str);           //字串轉數字
            Console.WriteLine("B01-int:" + iInt);

            _Str = "987.321";
            //iInt = Convert.ToInt16(_Str); //會錯誤
            //Console.WriteLine("02-int:" + iInt);
           
            
            _Str = "987.321";
            double dInt;
            dInt = Convert.ToDouble(_Str); 
            Console.WriteLine("B03-double:" + dInt);

            //iInt = dInt; //會錯誤
            iInt = (int)dInt; //強制轉型 誰大誰小要注意
            Console.WriteLine("B04-int:" + iInt);



            Console.ReadKey();


        }


    }



}
