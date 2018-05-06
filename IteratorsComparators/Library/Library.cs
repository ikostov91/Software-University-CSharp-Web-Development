using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    // Could be initilized without books or with any number of books with one constructor
    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(books);

        // yield return - shorter implementation

        // for (int i = 0; i < books.Count; i++)
        // {
        //     yield return books[i];
        // }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        public Book Current => books[index];

        object IEnumerator.Current => Current;

        private IReadOnlyList<Book> books;
        private int index;

        public LibraryIterator(IReadOnlyList<Book> books)
        {
            this.books = books;
            index = -1;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index++;
            return index < books?.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}

