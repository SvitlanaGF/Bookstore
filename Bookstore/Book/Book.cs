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
    }
}
