using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static _04_結構.Program;

namespace _04_結構
{
    internal class Program
    {
        #region Struct-Class
        //--------結構（Struct）
        //是一種實質型別（Value Type）。
        //存放在記憶體的Stack區。
        //不需要使用new就可以產生一份新的Struct。
        //若裡面有N個欄位，那麼一定要把N個欄位填滿，這個Struct才可以開始被使用。
        //不能擁有空參數的建構子（Constructor），若一定要寫建構子，則在建構子內要把所有欄位都指派值進去。
        //欄位不可以使用初始化賦值，請走建構子一途。
        //--------類別（Class）
        //是一種參考型別（Reference Type）。
        //存放在記憶體的Heap區。
        //一定要使用new來產生一份新的Instance。
        //若裡面有N個欄位，那麼不需要把N個欄位填滿，這個Instance才可以開始被使用。
        //能購擁有空參數的建構子（Constructor）。
        //欄位可以使用初始化賦值，例如：public string cName = "尚未命名";。
        //結構（Struct）與類別（Class）最大的差別
        //簡單的說，就是「效能」。使用「Stack」來存放的結構（Struct），在進行耗用大量記憶體來存放「資料」時，
        //基本上完全不會產生記憶體碎片化的問題，且在Struct離開Function時，
        //這些記憶體會馬上被Release出去，讓系統的記憶體佔用率極低。
        //反觀使用「Heap」來存放的類別（Class），，
        //在進行耗用大量記憶體來存放「資料」時，在那邊參考來參考去，
        //不僅造成碎片化，且當程式設計師忘記把Reference釋出（Dispose、Null），
        //這些被佔用的記憶體甚至等到整個程式的生命週期結束後都不見得會被釋放掉（Release），
        //必須仰賴垃圾蒐集（GC, Garbage Collection）來幫我們回收。
        //引用於:https://slashview.com/archive2017/20170328.html


        #endregion




        static void Main(string[] args)
        {

            Person person001 = new Person( );
            person001.Name = "小明";
            person001.Id = "20230001";
            person001.PhoneNumber = "0912345678";
            person001.age = 22;
            Console.WriteLine("我叫:{0},員工編號是:{1}，手機號碼:{2}",
                person001.Name, person001.Id, person001.PhoneNumber, person001.age);

            PersonA person002;
            //Person person002 = new Person();
            person002.Name = "小華";
            person002.Id = "20230002";
            person002.PhoneNumber = "0987654321";
            person002.age = 23;
            Console.WriteLine("我叫:{0},員工編號是:{1}，手機號碼:{2}",
                person002.Name, person002.Id, person002.PhoneNumber, person002.age);


            Console.WriteLine("-----------Class-------------");
            MyClass MyPerson001 = new MyClass();
            MyPerson001.Name = "小明";
            MyPerson001.Id = "20230001";
            MyPerson001.PhoneNumber = "0912345678";
            MyPerson001.age = 22;
            Console.WriteLine("我叫:{0},員工編號是:{1}，手機號碼:{2}",
                MyPerson001.Name, MyPerson001.Id, MyPerson001.PhoneNumber, MyPerson001.age);


            Console.ReadKey();

        }

      

        public struct Person
        {
            string _Name;
            string _Id;
            string _PhoneNumber;
            int _age;
            public string Name
            {
                get { return _Name; }
                set
                {
                    _Name = value;
                    Console.WriteLine("Setting Name:" + value);
                }
            }
            public string Id
            {
                get { return _Id; }
                set { _Id = value; }
            }
            public string PhoneNumber
            {
                get { return _PhoneNumber; }
                set { _PhoneNumber = value; }
            }

            public int age
            {
                get { return _age; }
                set { _age = value; }
            }

        }

        public struct PersonA
        {
            public string Name;
            public string Id;
            public string PhoneNumber;
            public int age;
        }
        public struct PersonB
        {
            public int Name;
            public int Id;
            public int PhoneNumber;
            public int age;
        }

        class MyClass
        {
            string _Name;
            string _Id;
            string _PhoneNumber;
            int _age;
            public string Name
            {
                get { return _Name; }
                set
                {
                    _Name = value;
                    Console.WriteLine("Setting Name:" + value);
                }
            }
            public string Id
            {
                get { return _Id; }
                set { _Id = value; }
            }
            public string PhoneNumber
            {
                get { return _PhoneNumber; }
                set { _PhoneNumber = value; }
            }
            public int age
            {
                get { return _age; }
                set { _age = value; }
            }
        }

    






    }
}
