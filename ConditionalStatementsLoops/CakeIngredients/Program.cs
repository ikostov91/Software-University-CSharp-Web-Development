using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            int ingredients = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Bake!" )
                {
                    break;
                }

                Console.WriteLine("Adding ingredient {0}.", input);
                ingredients++;
            }

            Console.WriteLine("Preparing cake with {0} ingredients.", ingredients);
        }
    }
}
