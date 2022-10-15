using System;
using System.Collections.Generic;
using System.Text;
using Bookstore.Book;

namespace Bookstore.Reader
{
    class Reader
    {
        public string Name { get; set; }
        private double Cash;
        private readonly Shop.Shop TheBestShop;
        private List<Book.Book> UsersBooks;
        private List<Book.Book> FavouriteBooks;


        public Reader(Shop.Shop theBestShop, string Name, double Cash)
        {
            UsersBooks = new List<Book.Book>();
            this.Name = Name;
            this.Cash = Cash;
            TheBestShop = theBestShop;
            TheBestShop.NotifyUser += TheBestShop_NotifyUser;
        }
        public Shop.Shop GetShop
        {
            get { return TheBestShop; }
        }
        public double cash
        {
            get { return Cash; }
            set { Cash = value; }
        }
        public List<Book.Book> UsrBooks
        {
            get { return UsersBooks; }
        }
        public List<Book.Book> FavBooks
        {
            get { return FavouriteBooks; }
        }
        private void TheBestShop_NotifyUser(string mess, Book.Book book)
        {
            /*Console.WriteLine(mess);
            string answ = Console.ReadLine();
            if( answ.ToLower() == "yes")
            {
                if(book.Price <= Cash)
                {
                    Cash -= book.Price;
                    UsersBooks.Add(book);
                    Console.WriteLine($"You add a book {book.Title}");
                }
                else
                {
                    Console.WriteLine("You are poor!!");
                }
            }
            else if(answ.ToLower() == "no")
            {
                Console.WriteLine("Ok!");
            }
            else
            {
                Console.WriteLine("You are radish!(");
            }*/
            Console.WriteLine(mess, " to ", this.Name);
            UsersBooks.Add(book);
        }
    }
}
