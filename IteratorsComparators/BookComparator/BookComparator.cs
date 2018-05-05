using System;
using System.Collections.Generic;
using System.Text;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book firstBook, Book secondBook)
    {
        var result = firstBook.Title.CompareTo(secondBook.Title);

        if (result == 0)
        {
            // first.CompareTo(second) sorts them in ascending order
            // second.CompareTo(first) sorts them in descending order
            result = secondBook.Year.CompareTo(firstBook.Year);

            // Another way to sort in descending order
            // (firstBook.Year.CompareTo(secondBook.Year)) * -1
        }

        return result;
    }
}

