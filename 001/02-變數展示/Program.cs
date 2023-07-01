using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _02_變數展示
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 資料型別     範圍                              占用記憶體
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




            int i = 10;
            Console.WriteLine("int:" + i);
            double d = 3.14159;
            Console.WriteLine("double:" + d);

            string StrName = "MyName";
            Console.WriteLine("string:" + StrName);

            char c = 'A';
            Console.WriteLine("char:" + c);

            c = StrName[0];
            Console.WriteLine("StrName[0] char:" + c);

            StringBuilder SB = new StringBuilder("ABC", 50);
            SB.Append(new char[] { 'D', 'E', 'F' });
            SB.Append("MyNameStringBuilder");
            SB.AppendFormat("GHI{0}{1}", 'J', 'k');
            Console.WriteLine("{0} chars: {1}", SB.Length, SB.ToString());

            decimal money = 9000m;
            Console.WriteLine("decimal:" + money);


            // 十進位：不含任何前置詞
            //十六進位：含有 0x 或 0X 前置詞
            //二進位：含 0b 或 0B 前置詞
            int intA;
            intA = 10;
            Console.WriteLine("int01---intA = 10 is " + intA);
            intA = 0xB;
            Console.WriteLine("int02---intA = 0xB is " + intA);
            intA = 0b_0010_1010;
            Console.WriteLine("int03---intA = 0b_0010_1010 is " + intA);
            // intA = 55.22; //會錯誤

            double doubleA;
            doubleA = 10;
            Console.WriteLine("double01---doubleA = 10 is " + doubleA);
            doubleA = 10.987;
            Console.WriteLine("double02---doubleA = 10.987 is " + doubleA);
            doubleA = -78.82;
            Console.WriteLine("double03---doubleA = -78.82 is " + doubleA);

            intA = 8;
            doubleA = intA;
            Console.WriteLine("double04---doubleA = intA is " + doubleA);
            doubleA = 7.6;
            //intA = doubleA;  //會錯誤
            intA = (int)doubleA;  //強制轉型
            Console.WriteLine("double05---doubleA = intA is " + doubleA);

            doubleA = 5.4;
            intA = Convert.ToInt32(doubleA);
            Console.WriteLine("double06---intA = Convert.ToInt32(doubleA) is " + doubleA);

            doubleA = 3.2;
            //intA =int.Parse(doubleA); //會錯誤
            //intA = int.Parse(doubleA.ToString()); //會錯誤
            //Console.WriteLine("double06--- intA = int.Parse(doubleA.ToString()) is " + doubleA);




            byte byteA;
         
            //-----byte--------
            byteA = 55;
            Console.WriteLine("A04---byteA = 55 is " + byteA);
            // byteA = 256; //會錯誤
            //Console.WriteLine("A05---byteA = 256:" + byteA);

            byteA = 0xF2;
            Console.WriteLine("A06---byteA = 0xF2 (10進制) is " + byteA); //
            Console.WriteLine("A07---byteA (16進制) is " + byteA.ToString("X2"));
            Console.WriteLine($"A08---byteA (16進制) is {byteA:X}");
            Console.WriteLine("A09---byteA (16進制) is {0}", byteA);





            Console.ReadKey();

        }


    }
}
