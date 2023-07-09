using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_面向對象
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //面向對象 三大特性
            //1.封裝
            //2.繼承
            //3.多態


            //1.封裝-------------------------------------------------------------
            Animal Dog = new Animal();
            Dog.Name = "狗";
            Dog.Hand = "0";
            Dog.Foot = "4";

            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", Dog.Name, Dog.Hand, Dog.Foot);

            //建構方法
            //Animal Cat = new Animal(string name, string hand, string foot);
            Animal Cat = new Animal("貓", "0", "4");
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", Cat.Name, Cat.Hand, Cat.Foot);

            //2.繼承-----------------------------------------
            bear bearA = new bear("熊貓", "2", "2");
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳,身高{3}", bearA.Name, bearA.Hand, bearA.Foot, bearA.tall);
            
            bear bearB = new bear("貓熊", "2", "2",205);
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳,身高{3}", bearB.Name, bearB.Hand, bearB.Foot, bearB.tall);

            Animal animal = new Animal("動物", "2", "2");
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", animal.Name, animal.Hand, animal.Foot);
            animal.sound();

            Dog dog1 = new Dog("旺財", "0", "4");
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", dog1.Name, dog1.Hand, dog1.Foot);
            dog1.sound();
            cat cat1 = new cat("小咪", "0", "4");
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", cat1.Name, cat1.Hand, cat1.Foot);
            cat1.sound();
            fox fox1 = new fox("火狐", "0", "4");
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", fox1.Name, fox1.Hand, fox1.Foot);
            fox1.sound();

            Animal anima2 = new Dog("動物2", "2", "2");
            Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", anima2.Name, anima2.Hand, anima2.Foot);
            anima2.sound();

            //cat anima3 = new Animal("動物2", "2", "2");
            //Console.WriteLine("這是一隻{0},有{1}隻手,有{2}隻腳", anima3.Name, anima3.Hand, anima3.Foot);
            //anima2.sound();


            Console.WriteLine("--------------------Animal[] anima4-------------------");
            Animal[] anima4 = { dog1, cat1, fox1 };

            for (int i = 0; i < anima4.Length; i++)
            {
               
                //if (anima4[i] is Animal)
                //{
                //    Console.WriteLine("--------------------is Animal-------------------");
                //}
                if (anima4[i] is Dog)
                {
                    Console.WriteLine("--------------------is Dog-------------------");
                }
                if (anima4[i] is cat)
                {
                    Console.WriteLine("--------------------is cat-------------------");
                }
                if (anima4[i] is fox)
                {
                    Console.WriteLine("--------------------is fox-------------------");
                }
                anima4[i].sound();
            }

            Console.ReadKey();
        }


    }


}
