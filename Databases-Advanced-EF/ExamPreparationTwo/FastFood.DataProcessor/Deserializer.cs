using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
			List<Employee> validEmployees = new List<Employee>();
            StringBuilder sb = new StringBuilder();

		    var deserializedEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

		    foreach (var employeeDto in deserializedEmployees)
		    {
		        if (!IsValid(employeeDto))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        Position position = GetOrCreatePosition(context, employeeDto.Position);
                
                Employee employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                };

                validEmployees.Add(employee);
		        sb.AppendLine(string.Format(SuccessMessage, employee.Name));
		    }

            context.Employees.AddRange(validEmployees);
		    context.SaveChanges();

		    return sb.ToString().Trim();
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
			List<Item> validItems = new List<Item>();
            StringBuilder sb = new StringBuilder();

		    var deserializedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

		    foreach (var itemDto in deserializedItems)
		    {
		        if (!IsValid(itemDto))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        bool itemExists = validItems.Any(x => x.Name == itemDto.Name);
		        if (itemExists)
		        {
		            continue;
		        }

		        Category category = GetOrCreateCategory(context, itemDto.Category);

                Item item = new Item
                {
                    Name = itemDto.Name,
                    Category = category,
                    Price = itemDto.Price
                };

                validItems.Add(item);
		        sb.AppendLine(string.Format(SuccessMessage, item.Name));
		    }

            context.Items.AddRange(validItems);
		    context.SaveChanges();

		    return sb.ToString().Trim();
		}

	    public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
			List<Order> validOrders = new List<Order>();
            StringBuilder sb = new StringBuilder();

		    var xml = XDocument.Parse(xmlString);
		    var deserializedOrders = xml.Element("Orders");

		    foreach (var orderElement in deserializedOrders.Elements())
		    {
		        Order order = new Order();

		        var customer = orderElement.Element("Customer").Value;
		        order.Customer = customer;

		        var employee = FindEmployee(context, orderElement.Element("Employee").Value);
		        if (employee == null)
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }
		        order.Employee = employee;

		        OrderType orderType = Enum.Parse<OrderType>(orderElement.Element("Type").Value);
		        order.Type = orderType;

		        DateTime orderDateTime = DateTime.ParseExact(orderElement.Element("DateTime").Value, "dd/MM/yyyy HH:mm",
		            CultureInfo.InvariantCulture);
		        order.DateTime = orderDateTime;

                var orderItems = new List<OrderItem>();

		        var itemsElements = orderElement.Element("Items").Elements();
		        foreach (var itemElement in itemsElements)
		        {
		            var item = FindItem(context, itemElement.Element("Name").Value);
		            if (item == null)
		            {
		                sb.AppendLine(FailureMessage);
		                continue;
		            }

		            int itemQuantity = int.Parse(itemElement.Element("Quantity").Value);
                    var orderItem = new OrderItem() { Item = item, Quantity = itemQuantity };

                    orderItems.Add(orderItem);
		        }

		        order.OrderItems = orderItems;
		        if (!IsValid(order))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

                validOrders.Add(order);
		        sb.AppendLine(string.Format("Order for {0} on {1} added", order.Customer, order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
		    }

            context.Orders.AddRange(validOrders);
		    context.SaveChanges();

		    return sb.ToString().Trim();
		}

	    private static Item FindItem(FastFoodDbContext context, string itemName)
	    {
	        var item = context.Items.FirstOrDefault(x => x.Name == itemName);
	        return item;
	    }

	    private static Employee FindEmployee(FastFoodDbContext context, string employeeName)
	    {
	        var employee = context.Employees.FirstOrDefault(x => x.Name == employeeName);
	        return employee;
	    }

	    private static Position GetOrCreatePosition(FastFoodDbContext context, string positionName)
	    {
	        var position = GetPosition(context, positionName) ?? CreateAndGetPosition(context, positionName);
	        return position;
	    }

	    private static Position GetPosition(FastFoodDbContext context, string positionName)
	    {
	        var position = context.Positions.FirstOrDefault(x => x.Name == positionName);
	        return position;
	    }

        private static Position CreateAndGetPosition(FastFoodDbContext context, string positionName)
	    {
	        var position = new Position { Name = positionName };

	        context.Positions.Add(position);
	        context.SaveChanges();

	        return position;
	    }

	    private static Category GetOrCreateCategory(FastFoodDbContext context, string categoryName)
	    {
	        var category = GetCategory(context, categoryName) ?? CreateAndGetCategory(context, categoryName);
	        return category;
	    }

	    private static Category GetCategory(FastFoodDbContext context, string categoryName)
	    {
	        var category = context.Categories.FirstOrDefault(x => x.Name == categoryName);
	        return category;
	    }

	    private static Category CreateAndGetCategory(FastFoodDbContext context, string categoryName)
	    {
	        var category = new Category { Name = categoryName };

	        context.Categories.Add(category);
	        context.SaveChanges();

	        return category;
	    }

	    public static bool IsValid(object obj)
	    {
	        var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

	        return Validator.TryValidateObject(obj, validationContext, results, true);
	    }
	}
}