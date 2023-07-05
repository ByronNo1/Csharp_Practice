using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SwitchCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請選擇語言:English(E):Chinese(C):Japanese(J)");
            string Lanuage = Console.ReadLine();

            //switch (Lanuage)
            switch (Lanuage.ToUpper())
            {
                case "ENGLISH":
                case "E":
                    Console.WriteLine("You Choose English");
                    break;
                case "CHINESE":
                case "C":
                    Console.WriteLine("你選擇華語");
                    break;
                case "JAPANESE":
                case "J":
                    Console.WriteLine("あなたは日本語を選択します");
                    break;
                case "":
                    Console.WriteLine("沒有選擇");
                    break;
                default:
                    Console.WriteLine("選擇錯誤");
                    break;
            }


            int inStep = 0;
            Console.WriteLine("輸入 0 或 1");
            inStep = Convert.ToInt16(Console.ReadLine());
            switch (inStep)
            {
                case 0:
                    Console.WriteLine("0");
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
                default:
                    Console.WriteLine("輸入非 0 非 1");
                    break;
            }




            Console.ReadKey();


        }

    }


}
