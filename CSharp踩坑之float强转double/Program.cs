using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp踩坑之double强转float
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 83459338;
            float f = (float)d;//83459336
            double diff = f - d; //2
                      
        }
    }
}
