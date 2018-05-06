using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Library Library = new Library();
            Library.Books = new List<Book>();

            Library.Name = "MyLibrary";

            int numberOfBooks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBooks; i++)
            {
                string[] currentBook = Console.ReadLine().Split(' ');

                DateTime date = DateTime.ParseExact(currentBook[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                decimal price = decimal.Parse(currentBook[5]);

                Book book = new Book()
                {
                    Title = currentBook[0],
                    Author = currentBook[1],
                    Publisher = currentBook[2],
                    ReleaseDate = date,
                    ISBNNumber = currentBook[4],
                    Price = price
                };

                Library.Books.Add(book);
            }

            Dictionary<string, decimal> booksByAuthor = new Dictionary<string, decimal>();

            foreach (var book in Library.Books)
            {
                if (!booksByAuthor.ContainsKey(book.Author))
                {
                    booksByAuthor.Add(book.Author, book.Price);
                }
                else
                {
                    booksByAuthor[book.Author] += book.Price;
                }
            }

            var result = booksByAuthor.OrderByDescending(x => x.Value).ThenBy(y => y.Key);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBNNumber { get; set; }
        public decimal Price { get; set; }
    }

    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
