using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Book
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public readonly DateTime DateOfCreation;
        public bool IsFavourite { get; set; }
        public Book(string Title, string Author, double Price)
        {
            this.Title = Title;
            this.Author = Author;
            this.Price = Price;
            DateOfCreation = DateTime.Now;
        }

        public static bool operator ==(Book b1, Book b2)
        {
            if(b1.Title == b2.Title && b1.Author == b2.Author)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Book b1, Book b2)
        {
            if (b1.Title != b2.Title || b1.Author != b2.Author)
            {
                return false;
            }
            return true;
        }
    }
}
