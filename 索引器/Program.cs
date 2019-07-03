using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 索引器
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            int a = mc["一"];
            Console.WriteLine(a);
            a = mc["二"];
            Console.WriteLine(a);
            a = mc["三"];
            Console.WriteLine(a);
        }
    }

    class MyClass
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        public int this[string str]
        {
            get
            {
                switch(str)
                {
                    case "一":return array[0];break;
                    case "二":return array[1];break;
                    case "三": return array[2]; break;
                    case "四": return array[3]; break;
                    default: throw new Exception("索引超出范围");
                }
            }
            set
            {
                switch(str)
                {
                    case "一":  array[0]=1; break;
                    case "二":  array[1]=2; break;
                    case "三":  array[2]=3; break;
                    case "四":  array[3]=4; break;
                    default:throw new Exception("索引超出范围");
                }
            }
        }
    }
}
