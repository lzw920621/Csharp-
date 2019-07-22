using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 不安全代码
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            //在同一个声明中声明多个指针时，星号 * 仅与基础类型一起写入；而不是用作每个指针名称的前缀。 例如:
            //int* p1, p2, p3;     // 正确  
            //int* p1, *p2, *p3;   // 错误 

            //int num1 = 10;
            //int* p1 = &num1;
            ////*p1 = 20;
            //Console.WriteLine((int)p1);
            //Console.WriteLine(*p1);// *p1 是 p1指向的对象
            //Console.WriteLine(p1->ToString());//p1->ToString() 是调用的p指向的对象的ToString方法
            //Console.ReadKey();


            int[] list = { 10, 100, 200 };

            //fixed关键字的作用:固定变量位置. 
            //因为GC在回收垃圾的时候会移动堆中对象的位置(碎片整理),如果一个变量的内存地址会变化，那么指针也就没有意义了
            //所以要固定ptr的位置
            fixed (int* ptr = list) //ptr为list[0]的地址                                   
            {                
                Console.WriteLine(*ptr);
                /* 显示指针中数组地址 */
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Address of list[{0}]={1}", i, (int)(ptr + i));//ptr+i为list[i]的地址
                    Console.WriteLine("Value of list[{0}]={1}", i, *(ptr + i));//*(ptr+i)为list[i]的值
                }
            }

            //在unsafe不安全环境中，我们可以通过stackalloc在堆栈上分配内存
            //其在堆栈上分配的内存不受内存管理器管理，因此其相应的指针不需要固定。
            //该内存块的生存期受限于定义它的方法的生存期。 不能在方法返回之前释放内存
            //int* ptr2 = stackalloc int[1];

            Console.ReadKey();
        }
    }
}
