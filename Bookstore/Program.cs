using Bookstore.Reader;
using Bookstore.Register;
using Bookstore.Shop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
//
namespace Bookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop.Shop a = new Shop.Shop("Belle");
            Filler f = new Filler();
            Shop.Shop b = new Shop.Shop("Bookland");
            List<Book.Book> books = f.Books();
            for (int i = 0; i < f.Books().Count; i++) {
                a.AddBook(f.Books()[i]);
                b.AddBook(f.Books()[i]);
            }
            List<Shop.Shop> shps = f.Shops();
            
            Dictionary<string, Shop.Shop> all_bookstores = new Dictionary<string, Shop.Shop>() { { "FlipperAndLopaka21", a},{"Ogust1Renuar9", b} };
            for (int i = 0; i < shps.Count; i++)
            {
                all_bookstores.Add($"LittlePrince{i}", shps[i]);
            }
            Dictionary<string, Reader.Reader> all_readers = new Dictionary<string, Reader.Reader>();

           

            //menu
            f.Menu(all_bookstores, all_readers, books);

        }
    }
}
