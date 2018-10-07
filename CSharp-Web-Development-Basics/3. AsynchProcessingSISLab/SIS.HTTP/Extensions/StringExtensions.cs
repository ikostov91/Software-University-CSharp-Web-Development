using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1).ToLower();
        }

        public static string[] TakeAllButLast(this string[] strArray)
        {
            string[] result = strArray.Take(strArray.Length - 1).ToArray();
            return result;
        }
    }
}
