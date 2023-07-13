using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_擴充方式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] ArrayDoubles = { 1, 2.5, 3.5, 7.5, 9.5 };
            double Doubles0 = 0;
            double Doubles1 = 0;
            double Doubles2 = 0;
            double Doubles3 = 0;
            for (int i = 0; i < ArrayDoubles.Length; i++)
            {
                Doubles0 += ArrayDoubles[i];
            }
            Doubles0 = Doubles0 / ArrayDoubles.Length;
            Console.WriteLine("Doubles0:" + Doubles0);

            Doubles1 = ArrayDoubles.Average();

            Console.WriteLine("Doubles1:" + Doubles1);

            Doubles2 = ArrayDoubles.GetStandardDeviation();
            // Doubles2= MyConvert.GetStandardDeviation(ArrayDoubles);
            Console.WriteLine("Doubles2:" + Doubles2);

            List<double> listDou = new List<double>();
            listDou =  ArrayDoubles.ToList();

            Doubles3 = listDou.standardDeviation();
            Console.WriteLine("Doubles3:" + Doubles3);

            Console.ReadKey();



        }

    }

    public static class MyConvert
    {
        public static double GetStandardDeviation(this double[] _doubles)
        {
            double Average = _doubles.Average();
            double Sum = _doubles.Sum(d => Math.Pow(d - Average, 2));
            double StandardDeviation = Math.Sqrt(Sum / _doubles.Length);
            return StandardDeviation;
        }


        //https://www.delftstack.com/zh-tw/howto/csharp/csharp-standard-deviation/

        public static double standardDeviation(this IEnumerable<double> sequence)
        {
            double average = sequence.Average();
            double sum = sequence.Sum(d => Math.Pow(d - average, 2));
            return Math.Sqrt((sum) / sequence.Count());
        }


    }


}
