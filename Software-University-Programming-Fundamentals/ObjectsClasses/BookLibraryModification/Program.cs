using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryModification
{
    class Program
    {
        static void Main(string[] args)
        {
            Library MyLibrary = new Library();
            MyLibrary.Books = new List<Book>();

            int numberOfBooks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBooks; i++)
            {
                Book currentBook = Book.ReadBook();
                MyLibrary.Books.Add(currentBook);
            }

            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Dictionary<string, DateTime> BooksDictionary = new Dictionary<string, DateTime>();

            foreach (var book in MyLibrary.Books)
            {
                if (book.ReleaseDate > date)
                {
                    BooksDictionary.Add(book.Title, book.ReleaseDate);
                }
            }

            var result = BooksDictionary.OrderBy(x => x.Value).ThenBy(y => y.Key);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.ToString("dd.MM.yyyy")}");
            }
        }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        internal static Book ReadBook()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            Book book = new Book();

            book.Title = input[0];
            book.Author = input[1];
            book.Publisher = input[2];
            book.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            book.ISBN = input[4];
            book.Price = decimal.Parse(input[5]);

            return book;
        }
    }
}
