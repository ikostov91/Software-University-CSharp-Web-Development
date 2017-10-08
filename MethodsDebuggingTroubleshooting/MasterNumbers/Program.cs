using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                bool isMaster = CheckMasterNumber(i);

                if (isMaster == true)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool CheckMasterNumber(int number)
        {
            bool palindrome = IsPalindrome(number);
            bool sum = SumOfDigits(number);
            bool evenDigit = ContainsEvenDigit(number);

            if (palindrome == true && sum == true && evenDigit == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsPalindrome(int n)
        {
            string number = n.ToString();

            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool SumOfDigits(int n)
        {
            int sum = 0;

            while (n != 0)
            {
                int digit = n % 10;
                sum += digit;
                n /= 10;
            }

            if (sum % 7 != 0)
            {
                return false;
            }

            return true;
        }

        static bool ContainsEvenDigit(int n)
        {
            while (n != 0)
            {
                int digit = n % 10;
                n /= 10;

                if (digit % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
