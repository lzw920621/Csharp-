using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 在switch块中使用goto
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            switch(n)
            {
                case 1:goto default;
                case 2:goto case 4;
                case 3:break;
                case 4:break;
                case 5:break;
                case 6:break;
                case 7:break;
                default:break;
            }

        }
    }
}
