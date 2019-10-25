using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace float转int的一些注意点
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            When converting from float or double to int, we cannot use an implicit cast, 
            because data would be lost.  We need an explicit cast, as shown below.  
            When casting from float or double to int, the resulting value is truncated (rounded towards 0) 
            to get an integral result.
            */
            float f1 = 4.8f;
            //int n1 = f1;        // Compile-time error: cannot implicitly convert
            int n1 = (int)f1;     // Explicit cast, truncated, n1 = 4


            //If you want to round to the nearest integer, rather than truncating, 
            //you can use one of the methods in System.Convert.
            n1 = Convert.ToInt32(4.8f);   // Rounded, n1 = 5

            //The Convert method always rounds to the nearest integer, 
            //unless the result is halfway between two integers.  In this case, 
            //it rounds to the nearest even integer.
            n1 = Convert.ToInt32(8.5f);  // Rounded to nearest even, n1 = 8
            n1 = Convert.ToInt32(9.5f);  // Rounded to nearest even, n1 = 10

        }
    }
}
