using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数组的协变
{
    class Animal
    {

    }
    class Dog:Animal
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[3];
            animals[0] = new Dog();//协变
            animals[0] = new Animal();//无异常

            Dog[] dogs = new Dog[3];
            animals = dogs;   //其实这一步执行完后 animals其实变成了一个Dog[]
            var type=animals.GetType();
            string name = type.Name;
            //animals[0] = new Animal();//这里会出异常
            animals = new Animal[3];

            /*
            要注意区别数组的引用 和 数组元素的引用
            */
            Animal animal = new Animal();
            animal = new Dog();
            string name1 = animal.GetType().Name;



            Animal[] animals2 = new Dog[10];//
        }
    }
}
