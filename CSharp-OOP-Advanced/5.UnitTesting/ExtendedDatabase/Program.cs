using System;
using System.Linq;

namespace ExtendedDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
           // ExtendedDatabase db;
            try
            {
                ExtendedDatabase db = new ExtendedDatabase(Enumerable.Repeat(new Person(1, "Pesho"), 17).ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //foreach (var person in db)
            //{
            //    Console.WriteLine(person.ToString());
            //}
        }
    }
}
