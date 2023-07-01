using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_IF_ESLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("請輸入名字");
            //string name = Console.ReadLine();

            //if (name == "VIP" || name == "vip")   // if (name.ToUpper() == "VIP")
            //{
            //    Console.WriteLine("尊貴的 " + name + " 您好!");
            //    //Console.WriteLine("尊貴的 " + name.ToUpper() + " 您好!");
            //}
            //else 
            //{
            //    Console.WriteLine(name + " 您好!");
            //}


            //if (name == "VIP" || name == "vip")   // if (name.ToUpper() == "VIP")
            //{
            //    Console.WriteLine("尊貴的 " + name + " 您好!");
            //    //Console.WriteLine("尊貴的 " + name.ToUpper() + " 您好!");
            //}
            //else if (name != "")
            //{
            //    Console.WriteLine(name + " 您好!");
            //}
            //else 
            //{
            //    Console.WriteLine("你沒名字喔!");
            //}

            //try
            //{
                Console.WriteLine("計算BMI");
                Console.WriteLine("請輸入身高cm");
                double Tall;
                string tmpStr = Console.ReadLine();
                Tall = Convert.ToDouble(tmpStr);
                Console.WriteLine("請輸入體重 kg");
                double weight;
                tmpStr = Console.ReadLine();
                weight = Convert.ToDouble(tmpStr);

                if (/*Tall > 0 && */ Tall > 10)
                {
                    double BMI = 0;
                    Tall = Tall / 100;
                    //BMI = weight / Tall * Tall;
                    BMI = weight / (Tall * Tall);
                    // Console.WriteLine("你的BMI:" + BMI);
                    
                    Console.WriteLine("你的BMI:" + BMI.ToString("0.###"));  //BMI = 22.1119; 四捨五入 BMI = 22.112
                }
                else
                {
                    Console.WriteLine("身高輸入錯誤:" + Tall);
                }


            //}
            //catch (Exception Ex)
            //{
            //    //Console.WriteLine("有錯誤有錯誤:" + Ex);
            //    Console.WriteLine("有錯誤有錯誤:" + Ex.Message);
            //}
           
           



            Console.ReadKey();

        }


    }


}
