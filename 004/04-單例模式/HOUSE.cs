using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_單例模式
{
    internal class HOUSE
    {
        public int money;
        public string address;
        public int floor;
        private static HOUSE _instance;
        //私有建構 讓別人不能外部創造
        private HOUSE() 
        {
        }
        private static object _thisLock = new object();

        public static  HOUSE getInstance()
        {
            //        第一層判斷為了避免不必要的同步
            if (_instance == null)
            {
                lock (_thisLock)
                {
                    if (_instance == null)
                    {
                        _instance = new HOUSE();
                    }
                }
              
            }
            return _instance;
        }


    }


}
