using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
// in a process


namespace Bookstore
{
    abstract class Methods_for_menu     // abstract class with methods we use in ReaderMenu and AdminMenu
    {
        public void show_all_readers(List<Reader.Reader> readers) // show names of all reader in the list
        {
            Console.WriteLine(">>>>>>>>>>Readers<<<<<<<<<<");
            foreach (Reader.Reader sh in readers)
            {
                Console.WriteLine(sh.Name);
            }
        }
        public void find_book_in(List<Book.Book> books) // method for searching a book in the list
        {
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            var book = books.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
            if (book != null)
            {
                Console.WriteLine("There is the book is your list");
            }
            else
            {
                Console.WriteLine("We can't find it:(");
            }
        }
        public void show_all_books(List<Book.Book> books) // show information about all books in the list 
        {
            foreach (Book.Book b in books)
            {
                Console.WriteLine($"Author: {b.Author} -- Book: {b.Title} -- Price: {b.Price}");
            }

        }

        public void add_book(List<Book.Book> books, List<Book.Book> donor) // add book to the list from another book list
        {
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            var bookInList = books.Where(x => x.Title == ttl && x.Author == ath);
            if(bookInList == null)
            {
                var book = donor.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
                if (book != null)
                {
                    books.Add(book);
                    Console.WriteLine($"'{book.Title}' has added.");
                }
                else
                {
                    Console.WriteLine("The book doesn't exist");
                }

            }
            else
            {
                Console.WriteLine($"You can't add a book '{ttl}', because it already exists.");
            }
        }
        public void create_and_add_book(Shop.Shop shop) // method for creating and adding a book to a shop you chose
        {
            Console.WriteLine("1 - random");
            Console.WriteLine("2 - yourself");
            int choise = int.Parse(Console.ReadLine());
            if (choise == 1)
            {
                Random random = new Random();

                string ttl = rand_str();
                string ath = rand_str();
                double prc = random.Next(150, 1300);
                shop.AddBook(new Book.Book(ttl, ath, prc));
            }
            else if (choise == 2)
            {
                Console.WriteLine("Title:");
                string ttl = Console.ReadLine();
                Console.WriteLine("Author:");
                string ath = Console.ReadLine();
                Console.WriteLine("Price:");
                double prc = Convert.ToDouble(Console.ReadLine());
                shop.AddBook(new Book.Book(ttl, ath, prc));
            }
        }

        public void add_all_books_to_shop(Shop.Shop shop, List<Book.Book> books) // add all books to the shop from list
        {

            foreach (Book.Book book in books)
            {
                shop.AddBook(book);
            }
        }

        public List<Reader.Reader> readers_for_shop(Shop.Shop shp, int number_of_readers)   // create readers for the shop you chose
        {
            Console.WriteLine("Do you want to create the list of readers yourself (write '1' below), or by random(write '2' below)?");
            int choise = int.Parse(Console.ReadLine());
            List<Reader.Reader> readers = new List<Reader.Reader>();
            switch (choise)
            {
                case 1:
                    for (int i = 0; i < number_of_readers; i++)
                    {
                        string name = Console.ReadLine();
                        double cash = double.Parse(Console.ReadLine());
                        readers.Add(new Reader.Reader(shp, name, cash));
                    }
                    break;
                case 2:
                    Random random = new Random();
                    for (int i = 0; i < number_of_readers; i++)
                    {

                        string name = rand_str();
                        double cash = random.Next(300, 50000);
                        readers.Add(new Reader.Reader(shp, name, cash));

                    }
                    break;

            }
            return readers;
        }

        public void delete_book(List<Book.Book> books) //delete book from list books
        {
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            var book = books.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
            if (book != null)
            {
                books.Remove(book);
            }
            else
            {
                Console.WriteLine("We can't find it:(");
            }
        }

        public string rand_str() //random string generator
        {
            Random random = new Random();
            string str = "";
            for (int j = 0; j < random.Next(5, 15); j++)
            {
                str += Convert.ToChar(random.Next(65, 91));
            }
            return str;
        }

        public void show_all_shops(List<Shop.Shop> shops) // show names of bookstores from list
        {
            Console.WriteLine(">>>>>>>>>>Shops<<<<<<<<<<");
            foreach (Shop.Shop sh in shops)
            {
                Console.WriteLine(sh.Name);
            }

        }

        public void find_a_book_in_bookstores(List<Shop.Shop> shops, Reader.Reader rdr) // method for searching a book in bookstores from list
        {
            Dictionary<string, Book.Book> dict_of_books = new Dictionary<string, Book.Book>();  // dictionary of bookstores with the book we search
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();

            foreach (Shop.Shop shp in shops)
            {
                var bk = shp.GetBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
                if (bk != null)
                {
                    dict_of_books.Add(shp.Name, bk);
                }
            }
            if (dict_of_books.Count() != 0) // if we find bookstores with a book we search, we'll show information about price of our book in these bookstores
            {
                foreach (KeyValuePair<string, Book.Book> kvp in dict_of_books)
                {
                    Console.WriteLine($"Store: {kvp.Key} ---- Book: {kvp.Value.Title} -- Price: {kvp.Value.Price}");
                }
                Console.WriteLine("Do you want buy this book?(Y/N)"); // our reader rdr can buy this book
                string answ = Console.ReadLine();
                if (answ.ToLower() == "y")
                {
                    Console.WriteLine("Please, write name of shop");
                    string shop = Console.ReadLine();
                    var book = dict_of_books.Where(x => x.Key == shop).FirstOrDefault().Value;
                    buy_book(book, rdr);
                }
                else if (answ.ToLower() == "n")
                {
                    Console.WriteLine("Ok:(");
                }
            }

        }

        public void buy_book(Book.Book book, Reader.Reader rdr) // method for buying book
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
        public void write_book_in_file(string fileName, List<Book.Book> all_books) // write list of books in a json file 
        {
            if (fileName.EndsWith(".json"))
            {
                string folder = @"D:\Lessons\L2\Bookstore\Bookstore\Books";
                string fullPath = folder + fileName;
                Filler f = new Filler();
                all_books = f.Books();
                string json = JsonConvert.SerializeObject(all_books);
                Console.WriteLine(json);
                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    writer.Write(json);

                }
            }
        }
    }
}
