using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var orders = context.Orders
                            .Where(x => x.Employee.Name == employeeName && x.Type.ToString() == orderType)
                            .Select(o => new
                            {
                                Customer = o.Customer,
                                Items = o.OrderItems
                                         .Select(oi => new
                                         {
                                             Name = oi.Item.Name,
                                             Price = oi.Item.Price,
                                             Quantity = oi.Quantity
                                         }).ToArray(),
                                TotalPrice = o.TotalPrice
                            })
                            .OrderByDescending(x => x.TotalPrice)
                            .ThenBy(x => x.Items.Length)
                            .ToArray();

            var employeeOrders = new
            {
                Name = employeeName,
                Orders = orders,
                TotalMoney = orders.Sum(x => x.TotalPrice)
            };

            var json = JsonConvert.SerializeObject(employeeOrders, Formatting.Indented);

            return json;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoryNames = categoriesString.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var categoryStats = context.Items
                .Where(x => categoryNames.Any(n => n == x.Category.Name))
                .GroupBy(x => x.Category.Name)
                .Select(g => new Dto.Export.CategoryDto
                {
                    Name = g.Key,
                    MostPopularItem = g.Select(x => new Dto.Export.ItemDto
                    {
                        Name = x.Name,
                        TotalMade = x.OrderItems.Sum(t => t.Item.Price * t.Quantity),
                        TimesSold = x.OrderItems.Sum(s => s.Quantity)
                    })
                    .OrderByDescending(y => y.TotalMade)
                    .ThenByDescending(z => z.TimesSold)
                    .First()
                })
                .OrderByDescending(dto => dto.MostPopularItem.TotalMade)
                .ThenByDescending(dto => dto.MostPopularItem.TimesSold)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryDto), new XmlRootAttribute("Categories"));
            var namespaces = new XmlSerializerNamespaces(new [] { new XmlQualifiedName("", "") });
            StringBuilder sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), categoryStats, namespaces);

            var result = sb.ToString().Trim();
            return result;
        }
    }
}