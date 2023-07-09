using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_集合
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("小明");
            list.Add("小華");
            list.Add("小誠");

            Console.WriteLine("List Count :" + list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("List {0} : {1}", i, list[i]);
            }

            list.Add("小北");
            Console.WriteLine("List Count :" + list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("List {0} : {1}", i, list[i]);
            }

            list.Clear();
            list.Add("小帥");
            Console.WriteLine("List Count :" + list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("List {0} : {1}", i, list[i]);
            }

            list.Add("小明");
            list.Add("小華");
            list.Add("小誠");
            list.Add("小北");
            Console.WriteLine("List Count :" + list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("List {0} : {1}", i, list[i]);
            }

            string[] ArrayStr = list.ToArray();
            Console.WriteLine("ArrayStr Count :" + ArrayStr.Length);
            for (int i = 0; i < ArrayStr.Length; i++)
            {
                Console.WriteLine("ArrayStr {0} : {1}", i, ArrayStr[i]);
            }

            list.Clear();
            Console.WriteLine("List Count :" + list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("List {0} : {1}", i, list[i]);
            }

            //list = ArrayStr.ToList();
            list.AddRange(ArrayStr);
            //list.AddRange(list);
            Console.WriteLine("List Count :" + list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("List {0} : {1}", i, list[i]);
            }

            //List<T> 泛型
            List<int> listInt = new List<int>();
            listInt = new List<int>() { 1, 1, 1, 12, 2, 3, 5 };
            // listInt =  {1,1,1, 12,2,3,5 }; error
            Console.WriteLine("listInt Count :" + listInt.Count);
            for (int i = 0; i < listInt.Count; i++)
            {
                Console.WriteLine("listInt {0} : {1}", i, listInt[i]);
            }



            List<string> listA = new List<string>();
            listA.Add("小明");
            listA.Add("小華");
            listA.Add("小明");
            listA.Add("小明");

            Console.WriteLine("listA Count :" + listA.Count);
            for (int i = 0; i < listA.Count; i++)
            {
                Console.WriteLine("listA {0} : {1}", i, listA[i]);
            }

            ////把listA 當成原始資料，listB 不要有重覆的DATA
            List<string> listB = new List<string>();
            //for (int i = 0; i < listA.Count; i++)
            //{
            //    listB.Add(listA[i]);
            //}

            bool isFind = false;
            for (int i = 0; i < listA.Count; i++)
            {
                isFind = false;
                //if (listB.Contains(listA[i]))
                //{
                //    isFind = true;
                //}
                for (int j = 0; j < listB.Count; j++)
                {
                    // if (listB[j] == listA[i])
                    if (listB[j].Equals(listA[i]))
                    {
                        isFind = true;
                        break;
                    }
                }
                if (isFind == false)
                {
                    listB.Add(listA[i]);
                }
            }


            Console.WriteLine("listB Count :" + listB.Count);
            for (int i = 0; i < listB.Count; i++)
            {
                Console.WriteLine("listB {0} : {1}", i, listB[i]);
            }
            Console.WriteLine("----------------- Dictionary  -------------------");
            Dictionary<string, string> DictionaryA = new Dictionary<string, string>();
            DictionaryA.Add("我", "帥帥");
            DictionaryA.Add("你", "很帥帥喔");
            DictionaryA.Add("她", "美美");

            foreach (KeyValuePair<string, string> de in DictionaryA)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }


            //for (int i = 0; i < DictionaryA.Count; i++)
            //{
            //    Console.WriteLine("DictionaryA {0} : {1}", i, DictionaryA[i]);
            //}

            Console.WriteLine("----------------- Hash Table  -------------------");
            // 雜湊表(Hash Table)又稱哈希表，是透過雜湊函式(Hash Function)來計算出一個鍵(key)與值(value)所對應的位置
            Hashtable NameHashtable = new Hashtable();
            NameHashtable.Add(1, "小帥");
            NameHashtable.Add(2, "小明");
            NameHashtable.Add(3, "小華");
            NameHashtable.Add(4, "小誠");
            NameHashtable.Add(5, "小北");
            NameHashtable[0] = "小李飛刀";
            NameHashtable.Add("ABB", "BBA");


            for (int i = 0; i < NameHashtable.Count; i++)
            {
                Console.WriteLine("NameHashtable {0} : {1}", i, NameHashtable[i]);
            }
            Console.WriteLine("------------------------");
            foreach (DictionaryEntry de in NameHashtable)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
            Console.WriteLine("------------------------");


            Console.WriteLine("NameHashtable {0} : {1}", "ABB", NameHashtable["ABB"]);
            // Console.WriteLine("NameHashtable {0} : {1}", "BBA", NameHashtable["BBA"]); //無法帶出
            Console.WriteLine("------------------------");
            //NameHashtable.Add(5, "浩南"); //有錯誤
            if (NameHashtable.ContainsKey(5))
            {
                NameHashtable[5] = "山雞哥";
            }
            if (NameHashtable.ContainsValue("BBA"))
            {
                NameHashtable.Remove("BBA");
            }

            for (int i = 0; i < NameHashtable.Count; i++)
            {
                Console.WriteLine("NameHashtable {0} : {1}", i, NameHashtable[i]);
            }

            if (NameHashtable.ContainsValue("山雞哥"))
            {

            }
            else
            {
                NameHashtable.Add(6, "山雞哥");
                NameHashtable[8] = "山雞哥";
            }

            for (int i = 0; i < NameHashtable.Count; i++)
            {
                Console.WriteLine("NameHashtable {0} : {1}", i, NameHashtable[i]);
            }


            Console.WriteLine("-----------------不要重複值集合 -------------------");

            //  HashSet
            HashSet<string> stringHashSet = new HashSet<string>();
            stringHashSet.Add("小帥");
            stringHashSet.Add("小明");
            stringHashSet.Add("小華");
            stringHashSet.Add("小誠");
            stringHashSet.Add("小北");
         

            //for (int i = 0; i < stringHashSet.Count; i++)
            //{
            //    Console.WriteLine("stringHashSet {0} : {1}", i, stringHashSet[i]);
            //}

            foreach (string item in stringHashSet)
            {
                Console.WriteLine("stringHashSet : {0}", item);
            }

            Console.WriteLine("-------------------- stringHashSet.Clear --------------------");
            stringHashSet.Clear();
            stringHashSet.Add("小北");

            foreach (string item in stringHashSet)
            {
                Console.WriteLine("stringHashSet : {0}", item);
            }
            Console.WriteLine("-------------------- stringHashSet.Clear --------------------");
            stringHashSet.Clear();

            stringHashSet.Add("小帥");
            stringHashSet.Add("小明");
            stringHashSet.Add("小華");
            stringHashSet.Add("小誠");
            stringHashSet.Add("小北");
            stringHashSet.Add("小北");
            stringHashSet.Add("小北");
            stringHashSet.Add("小北");
            foreach (string item in stringHashSet)
            {
                Console.WriteLine("stringHashSet : {0}", item);
            }

            Console.ReadKey();

        }


    }


}
