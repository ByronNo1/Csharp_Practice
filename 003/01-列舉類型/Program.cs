using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Days today;
            today = Days.Monday;
            Console.WriteLine(today);

            #region 與INT轉換
            Console.WriteLine((int)today);
            today = Days.Tuesday;
            today = Days.None;
            if (today == 0)
            {
                Console.WriteLine(today);
                Console.WriteLine("有錯誤的");
            }
            else
            {
                Console.WriteLine(today);
                Console.WriteLine((int)today);
            }

            today = (Days)7;
            Console.WriteLine(today);
            Console.WriteLine((int)today);
            #endregion
            #region 字串
            Console.WriteLine("-----------字串------------");
            Console.WriteLine(today.ToString());

            string s = "Monday";
            Days DaysB = (Days)Enum.Parse(typeof(Days), s);
            Console.WriteLine(DaysB);

            
            Console.WriteLine("-----------Days 所有 enum------------");
            foreach (Days item in Enum.GetValues(typeof(Days)))
            {
                Console.WriteLine(item + "({0})", (int)item);
            }

            Console.WriteLine("-----------Days 所有 String Name-----------");
            foreach (string item in Enum.GetNames(typeof(Days)))
            {
                Console.WriteLine(item);
            }


            #endregion

            Console.ReadKey();

        }


        public enum Days
        {
            None,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
            Weekend
        }




    }



}
