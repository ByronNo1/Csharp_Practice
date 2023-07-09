using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_字串處理
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _StrA = "ABC";
            string _StrB = new string(new char[] { 'A', 'B', 'C' });

            Console.WriteLine("String A:" + _StrA);
            Console.WriteLine("String B:" + _StrB);

            string _StrC = "WasD";
            Console.WriteLine("String C :" + _StrC);
            Console.WriteLine("String C Upper:" + _StrC.ToUpper());
            Console.WriteLine("String C Lower:" + _StrC.ToLower());
            Console.WriteLine("String C Length:" + _StrC.Length);

            for (int i = 0; i < _StrC.Length; i++)
            {
                Console.WriteLine("String C {0}:{1}", i, _StrC[i]);
            }
            Console.WriteLine("String C (1 to 2):" + _StrC.Substring(1, 2));

            string _StrD = "1,4,7,2,5,8";
            Console.WriteLine("String D :" + _StrD);
            int intPosition = 0;

            intPosition = _StrD.IndexOf(',');
            Console.WriteLine("',' 第一出現位置:" + intPosition);
            string _tmpStrD = "";

            //_tmpStrD = _StrD.Substring(intPosition , _StrD.Length - intPosition );
            //Console.WriteLine("_tmpStrD :" + _tmpStrD);

            if (_StrD.Length - (intPosition + 1) > 0)
            {
                _tmpStrD = _StrD.Substring(intPosition + 1, _StrD.Length - (intPosition + 1));
                Console.WriteLine("_tmpStrD :" + _tmpStrD);
                intPosition = _tmpStrD.IndexOf(',');
                //_tmpStrD = _tmpStrD.Substring(intPosition + 1, _tmpStrD.Length - (intPosition + 1));
                //Console.WriteLine("_tmpStrD :" + _tmpStrD);
                _tmpStrD = _tmpStrD.Substring(0, intPosition);
                Console.WriteLine("_tmpStrD :" + _tmpStrD);
            }

            intPosition = _StrD.IndexOf(",5");
            Console.WriteLine("',5' 第一出現位置:" + intPosition);
            _tmpStrD = _StrD.Substring(intPosition + ",5".Length, _StrD.Length - (intPosition + ",5".Length));
            Console.WriteLine("',5' 後面的字串 :" + _tmpStrD);


            string _StrE = "1,4,7,12,15,18";
            Console.WriteLine("String E :" + _StrE);
            string[] _tmpStrStr = _StrE.Split(',');
            for (int i = 0; i < _tmpStrStr.Length; i++)
            {
                Console.WriteLine(_tmpStrStr[i]);
            }
            Console.WriteLine("-------------------------------------------------------");

            string _StrF = "1,4,7,12,15,18-88~16$44";
            Console.WriteLine("String F :" + _StrF);

            string[] _tmpStrStrA = _StrF.Split(new char[] { ',', '~', '-', '$' });
            // _tmpStrStrA = _StrF.Split( ',', '~', '-', '$' );
            Console.WriteLine("----------------------',', '~', '-', '$' ---------------------------------");
            for (int i = 0; i < _tmpStrStrA.Length; i++)
            {
                Console.WriteLine(_tmpStrStrA[i]);
            }
           

            Console.WriteLine("-------------------------- 上限 -----------------------------");
            _tmpStrStrA = _StrF.Split(new char[] { ',' }, 3);
            for (int i = 0; i < _tmpStrStrA.Length; i++)
            {
                Console.WriteLine(_tmpStrStrA[i]);
            }

            string _StrG = "1,4,7,12,15,18-88~16$44";
            Console.WriteLine("String G : " + _StrG);
            _StrG = _StrG.Replace('~', ',');
            Console.WriteLine("String G Replace '~', ',' : " + _StrG);
            _StrG = "1,4,7,12,15,18-88~16$44";
            _StrG = _StrG.Replace("-88", "0");
            Console.WriteLine("String G Replace -88 , 0 : " + _StrG);

            string _StrH = " 4,7 ";
            Console.WriteLine("String H : " + _StrH);
            _StrH = _StrG.Trim();
            Console.WriteLine("String H Trim : " + _StrH);

            string _StrI = "47";
            Console.WriteLine("String I : " + _StrI);
            _StrI = _StrI.PadLeft(5, '0');
            Console.WriteLine("String I PadLeft(5, '0') : " + _StrI);
           
            _StrI = "47";
            _StrI = _StrI.PadRight(5, '0');
            Console.WriteLine("String I PadRight(5, '0') : " + _StrI);



            Console.ReadKey();

        }


    }

}
