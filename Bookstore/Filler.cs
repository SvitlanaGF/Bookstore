using System;
using System.Collections.Generic;
using System.Text;
// in a process

namespace Bookstore
{
    internal class Filler
    {
        Methods_for_menu n = new Methods_for_menu.Methods_for_menu();
        public List<Book.Book> Books()
        {
            var first_book = new Book.Book("Quixote", "Miguel de Cervantes Saavedra", 300.5);
            var second_book = new Book.Book("I am legend", "Richard Matheson", 350);
            var third_book = new Book.Book("The mind of a murderer", "Richard Taylor", 422.25);
            var fourth_book = new Book.Book("Bot", "Max Kidruk", 180.90);
            var fifth_book = new Book.Book("A killers mind", "Mike Omer", 342.52);
            return new List<Book.Book>() { first_book, second_book, third_book, fourth_book, fifth_book };
        }

        public List<Shop.Shop> Shops()
        {
            var BookWorld = new Shop.Shop("Book World");
            var Bbook = new Shop.Shop("Be book");
            return new List<Shop.Shop>() { BookWorld, Bbook };
        }

        public void add_all_books_to_shop(Shop.Shop shop, List<Book.Book> books)
        {

            foreach (Book.Book book in books)
            {
                shop.AddBook(book);
            }
        }

        public List<Reader.Reader> readers_for_shop(Shop.Shop shp, int number_of_readers)
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

                        string name = n.rand_str();
                        double cash = random.Next(300, 50000);
                        readers.Add(new Reader.Reader(shp, name, cash));

                    }
                    break;

            }
            return readers;
        }
    }
}
