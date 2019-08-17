using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型的协变和逆变
{
    //注意: 协变和逆变 只适用于 接口和委托

    class Animal
    {
        public int numOfLegs = 4;
    }
    class Dog:Animal
    {
        public void Run()
        {

        }
    }
    delegate T Factory<T>();

    delegate T NewFactory<out T>();//使用out关键字实现协变  类型参数只作为输出值(不能作为方法的参数输入,只作为返回值)


    delegate void Action1<in T>(T a);//使用in关键字实现逆变  类型参数只作为输入值(只作为方法的参数输入,不能作为返回值)

    class Program
    {
        static void Main(string[] args)
        {
            Factory<Dog> dogMaker = MakeDog;

            //不能隐式转换  虽然Dog派生自Animal,
            //但Factory<Dog>并没有从Factory<Animal>派生,
            //这两个委托对象是同级的
            // Factory<Animal> animalMaker = dogMaker;//错误
            //Factory<Animal> animalMaker = MakeDog;

            //协变 
            NewFactory<Dog> newDogMaker = MakeDog;
            NewFactory<Animal> newAnimalMaker = newDogMaker;

            //逆变
            Action1<Animal> act1 = ActOnAnimal;
            Action1<Dog> dog1 = act1;

            //Action1<Animal> animalAction = ActOnDog;//错误
            Action1<Dog> dogAction = ActOnAnimal;
            
        }
        static Dog MakeDog()
        {
            return new Dog();
        }

        static  void ActOnAnimal(Animal a)
        {
            Console.WriteLine(a.numOfLegs);
        }

        static void ActOnDog(Dog d)
        {
            Console.WriteLine(d.numOfLegs);
            d.Run();
        }
    }
}
