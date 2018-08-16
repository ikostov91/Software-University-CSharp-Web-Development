using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace ProductShop.App
{
    using AutoMapper;

    using Data;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            //ImportUsers(mapper, context);
            //ImportProducts(mapper, context);
            //ImportCategories(mapper, context);
            //GenerateCategoryForProducts(mapper, context);
            //ProductsInRange(mapper, context);
            //SuccessfullySoldProducts(mapper, context);
            //CategoriesByProductCount(mapper, context);
            UsersAndProducts(mapper, context);
        }

        public static void ImportUsers(IMapper mapper, ProductShopContext context)
        {
            var jsonString = File.ReadAllText("Json/users.json");
            var deserializedUsers = JsonConvert.DeserializeObject<User[]>(jsonString);

            List<User> users = new List<User>();

            foreach (var user in deserializedUsers)
            {
                if (IsValid(user))
                {
                    users.Add(user);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static void ImportProducts(IMapper mapper, ProductShopContext context)
        {
            string jsonString = File.ReadAllText("Json/products.json");
            var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(jsonString);

            List<Product> products = new List<Product>();

            foreach (var product in deserializedProducts)
            {
                if (!IsValid(product))
                {
                    continue;
                }
                var sellerId = new Random().Next(1, 35);
                var buyerId = new Random().Next(35, 57);

                product.SellerId = sellerId;
                product.BuyerId = buyerId;

                var random = new Random().Next(1, 4);
                if (random == 3)
                {
                    product.BuyerId = null;
                }

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static void ImportCategories(IMapper mapper, ProductShopContext context)
        {
            string jsonString = File.ReadAllText("Json/categories.json");
            var deserializedCategories = JsonConvert.DeserializeObject<Category[]>(jsonString);

            List<Category> categories = new List<Category>();

            foreach (var category in deserializedCategories)
            {
                if (!IsValid(category))
                {
                    continue;
                }

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void GenerateCategoryForProducts(IMapper mapper, ProductShopContext context)
        {
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 200; productId++)
            {
                var categoryId = new Random().Next(1, 12);

                var categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void ProductsInRange(IMapper mapper, ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    // seller = p.Seller.FirstName == null ? p.Seller.LastName : p.Seller.FirstName + " " + p.Seller.LastName
                    seller = p.Seller.FirstName + " " + p.Seller.LastName ?? p.Seller.LastName
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("Json/products-in-range.json", jsonProducts);
        }

        private static void SuccessfullySoldProducts(IMapper mapper, ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(y => y.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(s => new
                {
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    soldProducts = s.ProductsSold
                                    .Where(x => x.Buyer != null)
                                    .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price,
                                        buyerFirstName = p.Buyer.FirstName,
                                        buyerLastName = p.Buyer.LastName
                                    })
                                    .ToArray()
                })
                .ToArray();

            var jsonUsers = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText("Json/users-sold-products.json", jsonUsers);
        }

        private static void CategoriesByProductCount(IMapper mapper, ProductShopContext context)
        {
            var categories = context.Categories 
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Sum(z => z.Product.Price) / x.CategoryProducts.Count(),
                    totalRevenue = x.CategoryProducts.Sum(s => s.Product.Price)
                })
                .OrderByDescending(x => x.productsCount)
                .ToArray();

            var jsonUsers = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText("Json/categories-by-products.json", jsonUsers);
        }

        private static void UsersAndProducts(IMapper mapper, ProductShopContext context)
        {
            //var users = context.Users
            //    .Where(x => x.ProductsSold.Count >= 1)
            //    .Select(p => new
            //    {
            //        firstName = p.FirstName,
            //        lastName = p.LastName,
            //        age = p.Age,
            //        soldProducts = new
            //        {
            //            count = p.ProductsSold.Count,
            //            products = p.ProductsSold
            //                .Select(s => new
            //                {
            //                    name = s.Name,
            //                    price = s.Price
            //                })
            //                .ToArray()
            //        }
            //    })
            //    .OrderByDescending(p => p.soldProducts.count)
            //    .ThenBy(p => p.lastName)
            //    .ToArray();

            var users = new
            {
                usersCount = context.Users.Count(),
                users = context.Users
                            .Where(x => x.ProductsSold.Count >= 1 && x.ProductsSold.Any(y => y.Buyer != null))
                            .Select(p => new
                            {
                                firstName = p.FirstName,
                                lastName = p.LastName,
                                age = p.Age,
                                soldProducts = new
                                {
                                    count = p.ProductsSold.Count,
                                    products = p.ProductsSold
                                        .Select(s => new
                                        {
                                            name = s.Name,
                                            price = s.Price
                                        })
                                        .ToArray()
                                }
                            })
                            .OrderByDescending(p => p.soldProducts.count)
                            .ThenBy(p => p.lastName)
                            .ToArray()
            };


            var jsonUsers = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText("Json/users-and-products.json", jsonUsers);
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
