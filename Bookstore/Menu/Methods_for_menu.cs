using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
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
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"[{i+1}] - Author: {books[i].Author} -- Book: {books[i].Title} -- Price: {books[i].Price}");
            }

        }

        public void show_all_books_for_a_bookstore(List<Shop.Shop> all_shops, Reader.Reader rdr)
        {
            show_all_shops(all_shops);
            Console.WriteLine("Input bookstore number:");
            int srch = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(">>>>>>>>>>Books<<<<<<<<<<");
            if (srch > 0 && srch <= all_shops.Count + 1)
            {
                var shop = all_shops[srch - 1];
                show_all_books(shop.GetBooks);
                Console.WriteLine("Do you want buy a book from this list?(Y/N)");
                string answ = Console.ReadLine();
                if (answ.ToLower() == "y" || answ.ToLower() == "yes")
                {
                    Console.WriteLine("Write number of a book :");
                    int bk = Convert.ToInt32(Console.ReadLine());
                    if (bk > 0 && bk <= shop.GetBooks.Count)
                    {
                        var book = shop.GetBooks[bk - 1];
                        buy_book(book, rdr);
                    }

                }
                else if (answ.ToLower() == "n" || answ.ToLower() == "no")
                {
                    Console.WriteLine("Ok:(");
                }
                else
                {
                    Console.WriteLine("We can't find it:(");
                }
            }
        }

        public void add_book(List<Book.Book> books, List<Book.Book> donor) // add book to the list from another book list
        {
            Console.WriteLine("All books:");
            show_all_books(donor);
            Console.WriteLine("Input number of the book you want add:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0 && num <= (donor.Count+1))
            {
                var bookInList= books.Where(x=> x.Author == donor[num-1].Author && x.Title == donor[num-1].Title).FirstOrDefault();
                if (bookInList == null)
                {
                    books.Add(donor[num - 1]);
                    Console.WriteLine($"'{donor[num - 1].Title}' has added.");
                }
                else
                {
                    Console.WriteLine($"You can't add a book '{donor[num - 1].Title}', because it already exists.");
                }
            }
            else
            {
                Console.WriteLine($"You can't add this book.");
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
            Console.WriteLine("All books:");
            show_all_books(books);
            Console.WriteLine("Input number of the book you want buy:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0 && num <= (books.Count + 1))
            {
                books.Remove(books[num - 1]);
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
            for(int i =0;i<shops.Count;i++)
            {
                Console.WriteLine($"[{i+1}] {shops[i].Name}");
            }

        }

        public void find_a_book_in_bookstores(List<Shop.Shop> shops, Reader.Reader rdr) // method for searching a book in bookstores from list
        {
            Dictionary<string, Book.Book> dict_of_books = new Dictionary<string, Book.Book>();  // dictionary of bookstores with the book we search
            Console.WriteLine("Title:");
            string ttl = Console.ReadLine();
            Console.WriteLine("Author:");
            string ath = Console.ReadLine();
            List<Shop.Shop> list_of_shops = new List<Shop.Shop>();

            foreach (Shop.Shop shp in shops)
            {
                var bk = shp.GetBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
                if (bk != null)
                {
                    dict_of_books.Add(shp.Name, bk);
                    list_of_shops.Add(shp);
                }
            }
            if (dict_of_books.Count() != 0) // if we find bookstores with a book we search, we'll show information about price of our book in these bookstores
            {
                int i = 1;
                foreach (KeyValuePair<string, Book.Book> kvp in dict_of_books)
                {
                    Console.WriteLine($"[{i}] Store: {kvp.Key} ---- Book: {kvp.Value.Title} -- Price: {kvp.Value.Price}");
                    i += 1;
                }
                Console.WriteLine("Do you want buy this book?(Y/N)"); // our reader rdr can buy this book
                string answ = Console.ReadLine();
                if (answ.ToLower() == "y" || answ.ToLower() == "yes")
                {
                    Console.WriteLine("Please, write number shop");
                    int shop = Convert.ToInt32(Console.ReadLine());
                    var book = dict_of_books.Where(x => x.Key == list_of_shops[shop].Name).FirstOrDefault().Value;
                    buy_book(book, rdr);
                }
                else if (answ.ToLower() == "n" || answ.ToLower() == "no")
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
