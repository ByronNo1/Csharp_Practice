using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入名字");
            string name = Console.ReadLine();
           
            if (name == "VIP" || name == "vip")   // if (name.ToUpper() == "VIP")
            {
                Console.WriteLine("尊貴的 " + name + " 您好!");
                //Console.WriteLine("尊貴的 " + name.ToUpper() + " 您好!");
            }
            if (name != "")
            {
                Console.WriteLine( name + " 您好!");
            }
            Console.ReadKey();

        }


    }



}
