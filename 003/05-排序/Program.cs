using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string temp;
            string[] names = { "A", "B", "C", "D", "E", "F", "G" };

            for (int i = 0; i < names.Length / 2; i++)
            {
                temp = names[i];
                names[i] = names[names.Length - 1 - i];
                names[names.Length - 1 - i] = temp;
            }
            string[] namesA = new string[names.Length];
            temp = "";
            for (int i = 0; i < names.Length ; i++)
            {
                namesA[i] = names[names.Length- i - 1];
                temp += namesA[i] + ",";
            }

            Console.WriteLine("Reverse 0:" + temp);

            temp = "";
            for (int i = 0; i < names.Length; i++)
            {
                temp += names[i] + ",";
            }
            Console.WriteLine("Reverse 1:" + temp);
            temp = temp.TrimEnd(',');
            Console.WriteLine("Trim :".PadLeft("Reverse 1:".Length,' ') + temp);

            Array.Reverse(names);
            Console.WriteLine("Reverse 2:" + String.Join(",", names));

            Array.Reverse(names, 2, 3);
            Console.WriteLine("Reverse 3:" + String.Join(",", names));
            int[] nums = { 1, 4, 3, 9, 6, 8, 11 };
            //針對數陣列的排序
            Console.WriteLine("數陣列         :" + String.Join(",", nums));
            Array.Sort(nums);
            Console.WriteLine("陣列的排序 Sort:" + String.Join(",", nums));
            Console.WriteLine("----------------氣泡排序法(Bubble Sort)----------------");
            int X;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        X = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = X;
                    }
                }
            }
            Console.WriteLine("氣泡排序法:" + String.Join(",", nums));
            Console.ReadKey();



        }


    }


}
