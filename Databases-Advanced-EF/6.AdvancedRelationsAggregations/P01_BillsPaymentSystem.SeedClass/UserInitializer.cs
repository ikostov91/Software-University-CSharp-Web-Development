using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.SeedClass
{
   public class UserInitializer
    {
        public static User[] GetUsers()
        {
            User[] users = new User[]
            {
                new User() { FirstName = "Ivo", LastName = "Kostov", Email = "ikostov@gmail.com", Password = "123456"}, 
                new User() { FirstName = "Atanaska", LastName = "Chochkova", Email = "chochi@abv.bg", Password = "qwerty"}
            };

            return users;
        }
    }
}
