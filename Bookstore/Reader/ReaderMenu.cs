using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//to do:
//comments  

namespace Bookstore.Reader
{
    class ReaderMenu
    {
        public Reader rdr { get; set; }
        public ReaderMenu(Reader rdr)
        {
            this.rdr = rdr;
        }

        public void menu(List<Shop.Shop> all_shops)
        {
            Console.WriteLine($"Hi {rdr.Name}!");
            Console.WriteLine("Menu:");
            var flag = true;
            while (flag)
            {
                Console.Write("1 - show all shops\n2 - show all books in a shop\n3 - find a book in shops\n4 - show all books for a reader\n5 - add book to list of favourites\n6 - delete book from favourites\n7 - delete book from list of books\n8 - find book in list\n-1 - Exit");
                Console.WriteLine("Your Choise : ");
                var choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        show_all_shops(all_shops);
                        break;
                    case 2:
                        show_all_books_for_a_shop(all_shops);
                        break;
                    case 3:
                        find_a_book_in_bookstores(all_shops);
                        break;
                    case 4:
                        show_all_books_for_a_reader();
                        break;
                    case 5:
                        add_book_to_list_of_favourites();
                        break;
                    case 6:
                        delete_book_from_favourites();
                        break;
                    case 7:
                        delete_book_from_list();
                        break;
                    case 8:
                        find_book_in_list();
                        break;
                    case -1: flag = false; Console.WriteLine("GoodBye!"); break;
                    default:
                        break;
                }
            }
        }

       
        public void show_all_shops(List<Shop.Shop> shops)
        {
            Console.WriteLine(">>>>>>>>>>Shops<<<<<<<<<<");
            foreach (Shop.Shop sh in shops)
            {
                Console.WriteLine(sh.Name);
            }
            Console.WriteLine("Do you want visit one of them?");

        }

        public void show_all_readers(List<Reader> readers)
        {
            Console.WriteLine(">>>>>>>>>>Readers<<<<<<<<<<");
            foreach (Reader sh in readers)
            {
                Console.WriteLine(sh.Name);
            }
        }

        public void show_all_books_for_a_shop(List<Shop.Shop> all_shops)
        {
            Console.WriteLine("Shop:");
            string srch = Console.ReadLine();
            Console.WriteLine(">>>>>>>>>>Books<<<<<<<<<<");
            var shop = all_shops.Where(x => x.Name == srch).FirstOrDefault();
            if (shop != null)
            {
                foreach (Book.Book b in shop.GetBooks)
                {
                    Console.WriteLine($"Author: {b.Author} -- Book: {b.Title} -- Price: {b.Price}");
                }
                Console.WriteLine("Do you want buy a book from this list?(Y/N)");
                string answ = Console.ReadLine();
                if (answ.ToLower() == "y")
                {
                    Console.WriteLine("Title:");
                    string ttl = Console.ReadLine();
                    Console.WriteLine("Author:");
                    string ath = Console.ReadLine();
                    var book = shop.GetBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
                    if (book != null)
                    {
                        buy_book(book);
                    }

                }
                else if(answ.ToLower() == "n")
                {
                    Console.WriteLine("Ok:(");
                }
            }
            else
            {
                Console.WriteLine("We can't find it:(");
            }
        }

        public void find_a_book_in_bookstores(List<Shop.Shop> shops)
        {
            Dictionary<string, Book.Book> dict_of_books = new Dictionary<string, Book.Book>();  // dictionary of bookstores with the book we search
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();

            foreach(Shop.Shop shp in shops)
            {
                var bk = shp.GetBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
                if (bk != null)
                {
                    dict_of_books.Add(shp.Name, bk);
                }
            }
            if(dict_of_books.Count() != 0)
            {
                foreach(KeyValuePair<string,Book.Book> kvp in dict_of_books)
                {
                    Console.WriteLine($"Store: {kvp.Key} ---- Book: {kvp.Value.Title} -- Price: {kvp.Value.Price}");
                }
                Console.WriteLine("Do you want buy this book?(Y/N)");
                string answ = Console.ReadLine();
                if(answ.ToLower() == "y")
                {
                    Console.WriteLine("Please, write name of shop");
                    string shop = Console.ReadLine();
                    var book = dict_of_books.Where(x => x.Key == shop).FirstOrDefault().Value;
                    buy_book(book);
                }
                else if(answ.ToLower() == "n")
                {
                    Console.WriteLine("Ok:(");
                }
            }

        }

        public void show_all_books_for_a_reader()
        {
            foreach (Book.Book b in rdr.UsrBooks)
            {
                Console.WriteLine($"Author: {b.Author} -- Book: {b.Title}");
            }
        }

        public void add_book_to_list_of_favourites()
        {
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            var book = rdr.UsrBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault(); 
            rdr.FavBooks.Add(book);
        }

        public void delete_book_from_favourites()
        {
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            var book = rdr.FavBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
            if (book != null)
            {
                rdr.FavBooks.Remove(book);
            }
            else
            {
                Console.WriteLine("We can't find it:(");
            }
        }

        public void delete_book_from_list()
        {
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            var book = rdr.UsrBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
            if (book != null)
            {
                rdr.UsrBooks.Remove(book);
            }
            else
            {
                Console.WriteLine("We can't find it:(");
            }
        }

        public void find_book_in_list()
        {
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            var book = rdr.UsrBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
            if (book != null)
            {
                Console.WriteLine("There is the book is your list");
            }
            else
            {
                Console.WriteLine("We can't find it:(");
            }
        }

        public void buy_book(Book.Book book)
        {
            if (book.Price <= rdr.cash)
            {
                rdr.cash -= book.Price;
                rdr.UsrBooks.Add(book);
                Console.WriteLine($"You add a book {book.Title}");
            }
            else
            {
                Console.WriteLine("You are poor:(");
            }
        }

    }
}
