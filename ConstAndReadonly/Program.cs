﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstAndReadonly
{
    class MyClass
    {
        public int a;
        public int b;

        public MyClass(int x,int y)
        {
            a = x;
            b = y;
        }
    }
    class Program
    {
        static readonly MyClass myClass = new MyClass(2, 3); 
        static void Main(string[] args)
        {
            

            
        }
    }
}
