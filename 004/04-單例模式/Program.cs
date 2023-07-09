using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_單例模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // HOUSE oUSE_1 = new HOUSE();
            HOUSE oUSE_1 = HOUSE.getInstance();
            oUSE_1.money = 1000 * 10000;
            oUSE_1.address = "台灣桃園市桃園區";
            oUSE_1.floor = 1;
            Console.WriteLine("第一間房子總價:{0},地點:{1},樓層:{2}", oUSE_1.money, oUSE_1.address, oUSE_1.floor);
            Console.WriteLine("-----------------------------------------------------");
            // HOUSE oUSE_2 = new HOUSE();
            HOUSE oUSE_2 = HOUSE.getInstance();
            oUSE_2.money = 5000 * 10000;
            oUSE_2.address = "台灣台北市信義區";
            oUSE_2.floor = 18;

            Console.WriteLine("第一間房子總價:{0},地點:{1},樓層:{2}", oUSE_1.money, oUSE_1.address, oUSE_1.floor);
            Console.WriteLine("第二間房子總價:{0},地點:{1},樓層:{2}", oUSE_2.money, oUSE_2.address, oUSE_2.floor);



            Console.ReadKey();

        }

    }


}
