using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_變數交換
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = 1;
            int n2 = 2;
            int TmpI;

            Console.WriteLine("原始==> n1:{0},n2:{1}",n1,n2);
            TmpI = n1;
            n1 = n2;
            n2 = TmpI;
            Console.WriteLine("交換==> n1:{0},n2:{1}", n1, n2);

            n1 = 3;
            n2 = 4;
            Console.WriteLine("第二種方式原始==> n1:{0},n2:{1}", n1, n2);

            n1 = n1 - n2;
            n2 = n1 + n2;
            n1 = n2 - n1;
            Console.WriteLine("第二種方式交換==> n1:{0},n2:{1}", n1, n2);
            Console.ReadKey();

        }

    }



}
