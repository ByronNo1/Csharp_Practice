using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字串方式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _StrA = "";
            StringBuilder _StrB = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch(); //計算時間
            double DouTime_1 = 0;
            double DouTime_2 = 0;
            int intCount = 50000;
            stopwatch.Start();
            for (int i = 0; i < intCount; i++)
            {
                _StrA += i.ToString();
            }
            stopwatch.Stop();
            DouTime_1 = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("T1: string 經過多少毫秒:{0}", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < intCount; i++)
            {
                _StrB.Append(i.ToString());
            }
            stopwatch.Stop();
            DouTime_2 = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"T2: StringBuilder 經過多少毫秒:{stopwatch.ElapsedMilliseconds}");

            Console.WriteLine(@"T1 - T2:
================>" + (DouTime_1- DouTime_2).ToString() + "ms");






            //  \跳脫字元
            Console.WriteLine("跳脫字元");
            Console.WriteLine("\t");
            //  Console.WriteLine($"\"); //有問題
            Console.WriteLine("\\");
            // Console.WriteLine($"\"); //有問題
            Console.WriteLine(@"\");  // 跳脫字元無效
            Console.WriteLine("\"");



            // 控制字元
            char CharC_A = '\r';     //回車
            string StrC_A = "\r";  
            char charTab = ' ';
            char charTabcA = '\t';
            string strTabs = " ";
            string strTabsA = "\t";

            string tabsB = "\n";       //換行
            string StrEnter = "\r\n";  //通常用的Enter



            //Unicode
            //UTF-16
            Console.WriteLine("\u0001");
            Console.WriteLine('\u0002');
            Console.WriteLine(@"\u0003");


            string StrU16_A = "\u0001\u0002";
            Console.WriteLine(StrU16_A);
            char CharU16_A = '\u0003';
            Console.WriteLine(CharU16_A);
            //CharU16_A = "\u0001\u0002";

            //UTF-32
            char stxc = '\U00000002';
            Console.WriteLine(stxc);



            string StrB = "😀";
            Console.WriteLine(StrB);
            StrB = "\ud83d\ude00"; //(高位在前，低位在後)
            Console.WriteLine(StrB);
            StrB = "\U0001F600";
            Console.WriteLine(StrB);


            Console.ReadKey();

        }

    }



}
