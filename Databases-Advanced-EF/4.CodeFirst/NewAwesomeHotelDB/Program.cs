using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewAwesomeHotelD.Models;

namespace NewAwesomeHotelDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new HotelDbContext();
            //var newEntry = new Room()
            //{
            //    BedCount = 1,
            //    Cost = 45.50m,
            //    IsAvailable = true,
            //    RoomNickname = "The Room",
            //    RoomNumber = 11,
            //    RoomType = RoomType.Standart.ToString(),
            //    KeyCards = new List<KeyCard>()
            //    {
            //        new KeyCard()
            //        {
            //            CardNumber = 123
            //        }
            //    }
            //};

            //context.Rooms.Add(newEntry);
            //context.SaveChanges();

            var room = context.Rooms.Find(1);

            Console.WriteLine("Hello, World!");
        }
    }
}
