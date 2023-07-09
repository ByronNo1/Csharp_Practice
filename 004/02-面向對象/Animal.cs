using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_面向對象
{
    //1.封裝----------------------------------
    internal class Animal
    {
        // 字段  =》 用於描述一個事物
        private string _name; //名稱
        private string _hand; //手
        private string _foot; //腳
        //封裝：把核心的隱藏起來，留接口給別人訪問。
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Hand 
        {
            get { return _hand; } 
            set { _hand = value; }
        }
        public string Foot 
        {
            get
            {
                return _foot;
            }
            set
            { 
            _foot = value; 
            }
        }
        
        //建構方法
        public Animal()
        {
        }
        
        //建構方法
        public Animal(string name, string hand, string foot)
        {
            this._name = name;
            this._hand = hand;
            this._foot = foot;
        }


        //私有屬性，只有自己能使用
        public string type;
        //public 任意的都可以呼叫
        public double weight;
        //只限父類與子類
        protected string color;
        //叫聲method ，被繼承後可以override(覆寫)必須宣告為 virtual
        public virtual void sound()
        {
            Console.WriteLine("叫叫叫");
        }



    }


    //2.繼承-----------------------------------------
    class bear : Animal
    {
        private int _tall;

        public int tall
        {
            get { return _tall; }
            set { _tall = value; }
        }
        //建構方法
        public bear(string name, string hand, string foot) : base(name, hand, foot)
        {
            _tall = 0;
        }
        public bear(string name, string hand, string foot,int tall) : base(name, hand, foot)
        {
            _tall = tall;
        }
    }

    //3.多態-----------------------------------------
    class Dog : Animal
    {
        public Dog(string name, string hand, string foot) : base(name, hand, foot)
        {
           
        }

        public override void sound()
        {
            Console.WriteLine("旺旺旺");
            // base.sound();
        }

    }

    class cat : Animal
    {
        public cat(string name, string hand, string foot) : base(name, hand, foot)
        {

        }

        public override void sound()
        {
            Console.WriteLine("喵喵喵");
            // base.sound();
        }

    }



    class fox : Animal
    {
        public fox(string name, string hand, string foot) : base(name, hand, foot)
        {

        }

        public override void sound()
        {
            Console.WriteLine("Ylvis的歌曲:nWhat Does the Fox Say?");
            // base.sound();
        }

    }



}
