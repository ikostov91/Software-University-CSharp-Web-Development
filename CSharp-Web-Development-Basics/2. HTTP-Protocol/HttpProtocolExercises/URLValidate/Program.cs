using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace URLValidate
{
    class Program
    {
        private const string urlPattern = @"[0-9]+)?\/?(?<path>[a-zA-Z]+\/)?((?<searchQuery>search\?.+)?|(?<file>[a-zA-Z]+\.[a-zA-Z]+))(?<fragment>\#[a-zA-Z]+)?$";
        private const string queryPattern = @"";

        static void Main(string[] args)
        {
            string encodedUrl = Console.ReadLine();
            string decodedUrl = WebUtility.UrlDecode(encodedUrl);

            string result = ValidateUrl(decodedUrl);

            Console.WriteLine(result);
        }

        private static string ValidateUrl(string url)
        {
            var match = Regex.Match(url, urlPattern);

            if (!match.Success)
            {
                return "Invalid URL";
            }

            StringBuilder sb = new StringBuilder();
            var groups = match.Groups;

            string protocol = groups.First(x => x.Name == "protocol").Value;
            string host = groups.First(x => x.Name == "domain").Value;

            string port = String.Empty;
            if (groups.Any(x => x.Name == "port"))
            {
                port = groups.First(x => x.Name == "port").Value;

                if (protocol == "http" && port == "443" || protocol == "https" && port == "80")
                {
                    return "Invalid URL";
                }
            }
            else
            {
                port = protocol == "http" ? "80" : "443";
            }

            string path = string.Empty;
            if (groups.Any(x => x.Name == "path"))
            {
                path = groups.First(x => x.Name == "path").Value;
            }
            else
            {
                path = "/";
            }

            if (groups.Any(x => x.Name == "searchQuery"))
            {
                string query = groups.First(x => x.Name == "searchQuery").Value;
                if (groups.Any(x => x.Name == "fragment"))
                {
                    string fragment = groups.First(x => x.Name == "fragment").Value;
                }
            }
            else if (groups.Any(x => x.Name == "file"))
            {
                
            }

            return protocol;
            Console.WriteLine(protocol);
        }
    }
}
