using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentIntegerSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                long Number = long.Parse(number);
                Console.WriteLine($"{number} can fit in");
                try
                {
                    sbyte sbyteNumber = sbyte.Parse(number);
                    Console.WriteLine("* sbyte");
                }
                catch (Exception)
                {

                }

                try
                {
                    byte byteNumber = byte.Parse(number);
                    Console.WriteLine("* byte");
                }
                catch (Exception)
                {

                }

                try
                {
                    short shortNumber = short.Parse(number);
                    Console.WriteLine("* short");
                }
                catch (Exception)
                {

                }

                try
                {
                    ushort ushortNumber = ushort.Parse(number);
                    Console.WriteLine("* ushort");
                }
                catch (Exception)
                {

                }

                try
                {
                    int intNumber = int.Parse(number);
                    Console.WriteLine("* int");
                }
                catch (Exception)
                {

                }

                try
                {
                    uint uintNumber = uint.Parse(number);
                    Console.WriteLine("* uint");
                }
                catch (Exception)
                {

                }

                try
                {
                    long longNumber = long.Parse(number);
                    Console.WriteLine("* long");
                }
                catch (Exception)
                {

                }

            }
            catch (Exception)
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
        }
    }
}
