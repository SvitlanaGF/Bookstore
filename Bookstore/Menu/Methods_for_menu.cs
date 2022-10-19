using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// in a process


namespace Bookstore
{
    abstract class Methods_for_menu
    {
        public void show_all_readers(List<Reader.Reader> readers)
        {
            Console.WriteLine(">>>>>>>>>>Readers<<<<<<<<<<");
            foreach (Reader.Reader sh in readers)
            {
                Console.WriteLine(sh.Name);
            }
        }


        /* public void show_all_books_for_a_reader(List<Reader.Reader> all_readers)
         {
             Console.WriteLine("Reader:");
             string srch1 = Console.ReadLine();
             Console.WriteLine(">>>>>>>>>>Books<<<<<<<<<<");
             var reader = all_readers.Where(x => x.Name == srch1).FirstOrDefault();
             if (reader != null)
             {
                 foreach (Book.Book b in reader.UsrBooks)
                 {
                     Console.WriteLine($"Author: {b.Author} -- Book: {b.Title}");
                 }
             }
             else
             {
                 Console.WriteLine("We can't find it:(");
             }
         }*/
        public void find_book_in(List<Book.Book> books)
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
        public void show_all_books(List<Book.Book> books)
        {
            foreach (Book.Book b in books)
            {
                Console.WriteLine($"Author: {b.Author} -- Book: {b.Title} -- Price: {b.Price}");
            }

        }

        public void add_book(List<Book.Book> books, List<Book.Book> donor)
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
        public void create_and_add_book(Shop.Shop shop)
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

        public void delete_book(List<Book.Book> books)
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

        public string rand_str()
        {
            Random random = new Random();
            string str = "";
            for (int j = 0; j < random.Next(5, 15); j++)
            {
                str += Convert.ToChar(random.Next(65, 91));
            }
            return str;
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

        public void find_a_book_in_bookstores(List<Shop.Shop> shops, Reader.Reader rdr)
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
            if (dict_of_books.Count() != 0)
            {
                foreach (KeyValuePair<string, Book.Book> kvp in dict_of_books)
                {
                    Console.WriteLine($"Store: {kvp.Key} ---- Book: {kvp.Value.Title} -- Price: {kvp.Value.Price}");
                }
                Console.WriteLine("Do you want buy this book?(Y/N)");
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

        public void buy_book(Book.Book book, Reader.Reader rdr)
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
