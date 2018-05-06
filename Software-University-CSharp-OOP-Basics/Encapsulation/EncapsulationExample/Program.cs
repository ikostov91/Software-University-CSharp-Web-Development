using System;

namespace EncapsulationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            //person.IncreaseAgeByOne().Print();
            person.IncreaseAgeByOne();
            person.Print();
        }
    }
}
