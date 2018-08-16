using System;
using System.Collections.Generic;
using DataAnotations = System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.App.Dto;
using ProductShop.App.Dto.Export;
using ProductShop.Data;
using ProductShop.Models;
using ProductDto = ProductShop.App.Dto.Export.ProductDto;
using UserDto = ProductShop.App.Dto.UserDto;

namespace ProductShop.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new ProductShopContext();

            var users = new Dto.Query4Dtos.UsersDto
            {
                Count = context.Users.Count(),
                User = context.Users.Select(x => new Dto.Query4Dtos.UserDto
                {
                    
                })

            };

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(Dto.Export.CategoryDto[]), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            File.WriteAllText("Xml/categories-by-products.xml", sb.ToString());
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            return mapper;
        }

        private static void ExportUsersAndProducts()
        {
            var context = new ProductShopContext();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x => new Dto.Export.CategoryDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    TotalRevenue = x.CategoryProducts.Sum(s => s.Product.Price),
                    AveragePrice = x.CategoryProducts.Select(s => s.Product.Price).DefaultIfEmpty(0).Average()
                })
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(Dto.Export.CategoryDto[]), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            File.WriteAllText("Xml/categories-by-products.xml", sb.ToString());
        }

        private static void ExportProductsInRange()
        {
            var context = new ProductShopContext();

            var products = context.Products
                .Where(x => x.Price >= 1000 && x.Price <= 2000 && x.Buyer != null)
                .OrderByDescending(x => x.Price)
                .Select(x => new ProductDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName ?? x.Buyer.LastName
                })
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            File.WriteAllText("Xml/products-in-range.xml", sb.ToString());
        }

        private static void ExportSoldProducts()
        {
            var context = new ProductShopContext();

            var users = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new Dto.Export.UserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(s => new SoldProductDto
                        {
                            Name = s.Name,
                            Price = s.Price
                        })
                        .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(Dto.Export.UserDto[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("Xml/users-sold-products.xml", sb.ToString());
        }

        private static void ImportUsers()
        {
            var mapper = CreateMapper();

            var xmlString = File.ReadAllText("Xml/users.xml");

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            var deserializedUsers = (UserDto[])serializer.Deserialize(new StringReader(xmlString));

            List<User> users = new List<User>();

            foreach (var userDto in deserializedUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }

                var user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            var context = new ProductShopContext();
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void ImportProducts()
        {
            var mapper = CreateMapper();

            var xmlString = File.ReadAllText("Xml/products.xml");

            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            var deserializedProducts = (ProductDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Product> products = new List<Product>();

            int counter = 1;

            foreach (var productDto in deserializedProducts)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }

                var product = mapper.Map<Product>(productDto);

                var buyerId = new Random().Next(1, 30);
                var sellerId = new Random().Next(31, 53);

                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                if (counter == 4)
                {
                    product.BuyerId = null;
                    counter = 0;
                }

                products.Add(product);
                counter++;
            }

            var context = new ProductShopContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportCategories()
        {
            var mapper = CreateMapper();

            string xmlString = File.ReadAllText("Xml/categories.xml");

            var serializer = new XmlSerializer(typeof(Dto.CategoryDto[]), new XmlRootAttribute("categories"));
            var deserializedCategories = (Dto.CategoryDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Category> categories = new List<Category>();

            foreach (var categoryDto in deserializedCategories)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }

                var category = mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            var context = new ProductShopContext();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportCategoryProducts()
        {
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 198; productId++)
            {
                var categoryId = new Random().Next(1, 11);

                var categoryProduct = new CategoryProduct()
                {
                    ProductId = productId,
                    CategoryId = categoryId
                };

                categoryProducts.Add(categoryProduct);
            }

            var context = new ProductShopContext();
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new DataAnotations.ValidationContext(obj);
            var validationResults = new List<DataAnotations.ValidationResult>();

            return DataAnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
