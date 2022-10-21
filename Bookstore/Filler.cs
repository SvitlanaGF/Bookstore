using System;
using System.Collections.Generic;
using System.Text;
// in a process

namespace Bookstore
{
    internal class Filler
    {
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
    }
}
