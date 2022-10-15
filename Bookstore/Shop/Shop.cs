using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Shop
{
    class Shop
    {
        public delegate void NewBook(string mess, Book.Book book);
        public event NewBook NotifyUser = delegate { };
        private List<Book.Book> Books;
        public string Name { get; set; }
        public Shop(string Name)
        {

            this.Name = Name;
            Books = new List<Book.Book>();
        }
        public List<Book.Book> GetBooks
        {
            get { return Books; }
        }
        public void AddBook(Book.Book book)
        {

            if (book == null)
            {
                Console.WriteLine("Pizdets!");
                return;
            }
            Books.Add(book);
            NotifyUser($"We add a new book {book.Title}))", book);
        }
    }
}
