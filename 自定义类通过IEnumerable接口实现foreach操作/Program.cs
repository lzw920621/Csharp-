using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义类通过IEnumerable接口实现foreach操作
{
    public class Person
    {
        public string _firstName;
        public string _lastName;
        public Person(string firstName,string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }
    /*
    public class People:IEnumerable
    {
        Person[] _people;
        public People(Person[] personArray)
        {
            //_people = new Person[personArray.Length];
            //for (int i = 0; i < personArray.Length; i++)
            //{
            //    _people[i] = personArray[i];
            //}
            _people = personArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PeopleEnum(_people);
        }

        private class PeopleEnum : IEnumerator
        {
            public Person[] _people;

            public PeopleEnum(Person[] list)
            {
                _people = list;
            }

            int position = -1;

            public bool MoveNext()
            {
                position++;
                return (position < _people.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    try
                    {
                        return _people[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

        }
    }
    */

    public class People : IEnumerable
    {
        Person[] _people;
        public People(Person[] personArray)
        {            
            _people = personArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _people.Length; i++)
            {
                yield return _people[i];
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Person[] peopleArray = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p._firstName + " " + p._lastName);

            Console.ReadKey();
        }
    }
}
