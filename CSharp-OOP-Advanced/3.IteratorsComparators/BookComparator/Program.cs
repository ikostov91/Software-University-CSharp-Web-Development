using System;

class Program
{
    static void Main(string[] args)
    {
        Book bookOne = new Book("Animal Farm", 2002, "George Orwell");
        Book bookTwo = new Book("The Documents in the Case", 2003, "Dorothy Sayers", "Robert Eustace");
        Book bookThree = new Book("The Documents in the Case", 1930);
        Book bookFour = new Book("My book", 2000, "No name");

        Library libraryOne = new Library();
        Library libraryTwo = new Library(bookOne, bookTwo, bookThree);
        libraryTwo.books.Add(bookFour);

        foreach (var book in libraryTwo)
        {
            Console.WriteLine(book);
        }
    }
}

