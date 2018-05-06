using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Book
{
    private const int MinTitleLength = 3;

    private string title;
    private string author;
    private decimal price;

    public string Author
    {
        get { return this.author; }
        protected set
        {
            if (!IsAuthorNameValid(value))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        protected set
        {
            if (value.Length < MinTitleLength)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        protected set
        {
            if (value <= 0m)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    private bool IsAuthorNameValid(string author)
    {
        string[] names = author.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        if (names.Length == 1)
        {
            if (char.IsDigit(names[0],0))
            {
                return false;
            }
        }
        else
        {
            if (char.IsDigit(names[1],0))
            {
                return false;
            }
        }

        return true;
    }

    public virtual string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Type: ").Append(this.GetType().Name)
            .Append(Environment.NewLine)
            .Append("Title: ").Append(this.Title)
            .Append(Environment.NewLine)
            .Append("Author: ").Append(this.Author)
            .Append(Environment.NewLine)
            .Append(String.Format("Price: {0:F2}", this.Price));

        string result = sb.ToString().TrimEnd();
        return result;
    }
}

