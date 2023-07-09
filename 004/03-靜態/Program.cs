using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 靜態
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HOUSE oUSE_1 = new HOUSE();
            oUSE_1.money = 1000 * 10000;
            oUSE_1.address = "台灣桃園市桃園區";
            oUSE_1.floor = 1;
            //Console.WriteLine("第一間房子總價:{0},地點:{1},樓層:{2}", oUSE_1.money, oUSE_1.address, oUSE_1.floor);

            HOUSE oUSE_2 = new HOUSE();
            oUSE_2.money = 5000 * 10000;
            oUSE_2.address = "台灣台北市信義區";
            oUSE_2.floor = 18;

            Console.WriteLine("第一間房子總價:{0},地點:{1},樓層:{2}", oUSE_1.money, oUSE_1.address, oUSE_1.floor);
            Console.WriteLine("第二間房子總價:{0},地點:{1},樓層:{2}", oUSE_2.money, oUSE_2.address, oUSE_2.floor);

            //HOUSE_2 hOUSE = new HOUSE_2();

            HOUSE_2.money = 3000 * 10000;
            HOUSE_2.address = "台灣台中市西屯區";
            HOUSE_2.floor = 15;
            //Console.WriteLine("第三間房子總價:{0},地點:{1},樓層:{2}", HOUSE_2.money, HOUSE_2.address, HOUSE_2.floor);
            
            HOUSE_2.money = 3500 * 10000;
            HOUSE_2.address = "台灣高雄市楠梓區";
            HOUSE_2.floor = 6;
            //Console.WriteLine("第三間房子總價:{0},地點:{1},樓層:{2}", HOUSE_2.money, HOUSE_2.address, HOUSE_2.floor);
            Console.WriteLine("第四間房子總價:{0},地點:{1},樓層:{2}", HOUSE_2.money, HOUSE_2.address, HOUSE_2.floor);


            ADD.X = 5;
            ADD.Y = 7;
            ADD.ADD1();

            int result =  ADD.S1(6, 7);
            Console.WriteLine(result);

            Console.ReadKey();


        }



    }

}
