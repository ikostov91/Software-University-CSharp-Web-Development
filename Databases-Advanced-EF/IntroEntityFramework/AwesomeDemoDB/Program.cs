using System;
using System.Linq;
using AwesomeDemoDB.Data;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDemoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AwesomeDemoDBContext();
            var enemies = context.Users.Include(x => x.Enemies).FirstOrDefault(x => x.Username == "Pesho")?.Enemies;
            Console.WriteLine(string.Join(", ",enemies.Select(x => x.Name)));
        }
    }
}
