using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pesho = new Person();

            //Console.WriteLine(pesho.Name + " " + pesho.Age);

            //pesho.Name = "Gosho";
            //pesho.Age = 31;

            //Console.WriteLine(pesho.Name + " " + pesho.Age);

            //pesho.SayHello();
            //pesho.Hungry();
            //Console.WriteLine(pesho.Name + " works " + pesho.WorkPerDay() + " hours per day!");

            pesho.Name = "Pesho";
            pesho.Age = 22;

            var gosho = new Person() { Age = 23, Name = "Gosho" };
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void SayHello()
        {
            Console.WriteLine("Hello!");
        }

        public void Hungry()
        {
            Console.WriteLine("I amd hungry!");
        }

        public int WorkPerDay()
        {
            return 8;
        }
    }
}
