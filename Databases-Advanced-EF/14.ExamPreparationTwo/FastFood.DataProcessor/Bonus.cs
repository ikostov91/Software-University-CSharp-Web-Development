using System;
using System.Linq;
using FastFood.Data;

namespace FastFood.DataProcessor
{
    public static class Bonus
    {
        private const string ItemNotFount = "Item {0} not found!";
        private const string PriceUpdated = "{0} Price updated from ${1:F2} to ${2:F2}";

        public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
        {
            var item = context.Items.SingleOrDefault(x => x.Name == itemName);

            if (item == null)
            {
                return string.Format(ItemNotFount, itemName);
            }

            decimal oldPrice = item.Price;
            item.Price = newPrice;
            context.SaveChanges();

            return string.Format(PriceUpdated, item.Name, oldPrice, item.Price);
        }
    }
}
