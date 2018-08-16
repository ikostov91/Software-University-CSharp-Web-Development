using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Z.EntityFramework.Plus;

namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                DbInitializer.ResetDatabase(context);

                string result = string.Empty;

                // Problem 1. Age Restriction
                //string command = Console.ReadLine();
                //result = GetBooksByAgeRestriction(context, command);

                // Problem 2. Golden Books
                // result = GetGoldenBooks(context);

                // Problem 3. Books By Price
                // result = GetBooksByPrice(context);

                // Problem 4. Not released in
                //int year = int.Parse(Console.ReadLine());
                //result = GetBooksNotRealeasedIn(context, year);

                // Problem 5. Book titles by category
                //string input = Console.ReadLine();
                //result = GetBooksByCategory(context, input);

                // Problem 6. Released before date
                //string date = Console.ReadLine();
                //result = GetBooksReleasedBefore(context, date);

                // Problem 7. Author Search
                //string input = Console.ReadLine();
                //result = GetAuthorNamesEndingIn(context, input);

                // Problem 8. Book Search
                //string input = Console.ReadLine();
                //result = GetBookTitlesContaining(context, input);

                // Problem 9. Book search by author
                //string input = Console.ReadLine();
                //result = GetBooksByAuthor(context, input);

                // Problem 10. Count books
                //int lengthCheck = int.Parse(Console.ReadLine());
                //int count = CountBooks(context, lengthCheck);

                // Problem 11. Total book copies
                //result = CountCopiesByAuthor(context);

                // Problem 12. Profit by category
                //result = GetTotalProfitByCategory(context);

                // Problem 13. Most recent books
                //result = GetMostRecentBooks(context);

                // Problem 14. IncreasePrices
                //IncreasePrices(context);

                // Problem 14.2 Increase Prices Bulk Update
                //IncreasePricesBulkUpdate(context);

                // Problem 15. Remove books
                //int removedBooksCount = RemoveBooks(context);

                // Problem 15.2 Remove books Bulk Delete
                int removedBooksCount = RemoveBooksBulkDelete(context);

                PrintResult(removedBooksCount + " books were deleted");
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            StringBuilder sb = new StringBuilder();

            var bookTitles = context.Books
                                .Where(x => x.AgeRestriction == ageRestriction)
                                .OrderBy(x => x.Title)
                                .Select(x => x.Title)
                                .ToArray();

            foreach (var bookTitle in bookTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooksTitles = context.Books
                .Where(x => x.EditionType == EditionType.Gold)
                .Where(x => x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            foreach (var bookTitle in goldenBooksTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context.Books
                .Where(x => x.ReleaseDate.GetValueOrDefault().Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            foreach (var bookTitle in bookTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] categories = input.ToLower().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var books = context.Books
                .Where(x => x.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime beforeDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < beforeDate)
                .Select(x => new
                {
                    Title = x.Title,
                    Type = x.EditionType.ToString(),
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Type} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x => x)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    Author = x.Author.FirstName + " " + x.Author.LastName
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    Name = x.FirstName + " " + x.LastName,
                    BookCopies = x.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(x => x.BookCopies)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Name} - {author.BookCopies}");
            }

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesProfits = context.Categories
                //.Include(x => x.CategoryBooks)
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Sum(y => y.Book.Price * y.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            foreach (var category in categoriesProfits)
            {
                sb.AppendLine($"{category.Name} ${category.Profit}");
            }

            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Include(x => x.CategoryBooks)
                .ThenInclude(x => x.Book)
                .OrderBy(x => x.Name)
                .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                var books = category.CategoryBooks
                    .Select(x => new
                    {
                        Title = x.Book.Title,
                        ReleaseDate = x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .Take(3)
                    .ToArray();

                foreach (var book in books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.GetValueOrDefault().Year})");
                } 
            }

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.GetValueOrDefault().Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5.0m;
            }

            context.SaveChanges();
        }

        public static void IncreasePricesBulkUpdate(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .Update(b => new Book() { Price = b.Price + 5});
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(x => x.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            return booksToRemove.Length;
        }

        public static int RemoveBooksBulkDelete(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .Delete();

            return books;
        }

        private static void PrintResult(string result)
        {
            Console.WriteLine(result);
        }

        private static void PrintResult(int result)
        {
            Console.WriteLine(result);
        }
    }
}
