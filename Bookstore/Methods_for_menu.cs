using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// in a process


namespace Bookstore
{
    class Methods_for_menu
    {
        public void show_all_shops(List<Shop.Shop> shops)
        {
            Console.WriteLine(">>>>>>>>>>Shops<<<<<<<<<<");
            foreach (Shop.Shop sh in shops)
            {
                Console.WriteLine(sh.Name);
            }
        }

        public void show_all_readers(List<Reader.Reader> readers)
        {
            Console.WriteLine(">>>>>>>>>>Readers<<<<<<<<<<");
            foreach (Reader.Reader sh in readers)
            {
                Console.WriteLine(sh.Name);
            }
        }

        public void show_all_readers_for_the_shop(List<Shop.Shop> shops, List<Reader.Reader> readers)
        {
            Console.WriteLine("Shop:");
            string srch = Console.ReadLine();
            var shop = shops.Where(x => x.Name == srch).FirstOrDefault();
            if (shop != null)
            {
                Console.WriteLine(">>>>>>>>>>Readers<<<<<<<<<<");
                var rdrs = readers.Where(x => x.GetShop == shop);
                if (rdrs.Count() != 0)
                {
                    foreach (Reader.Reader rd in rdrs)
                    {
                        Console.WriteLine(rd.Name);
                    }
                }
                else
                {
                    Console.WriteLine("We can't find it:(");
                }
            }
        }

        public void show_all_books_for_a_reader(List<Reader.Reader> all_readers)
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
            }
            else
            {
                Console.WriteLine("We can't find it:(");
            }
        }

        public void add_book_in_a_shop(List<Shop.Shop> all_shops)
        {
            Console.WriteLine("Input your shop:");
            string srch = Console.ReadLine();

            var shop = all_shops.Where(x => x.Name == srch).FirstOrDefault();
            if (shop != null)
            {
                create_and_add_book(shop);
            }
            else
            {
                Console.WriteLine("Error:(");
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
    }
}
