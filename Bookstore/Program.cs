using Bookstore.Reader;
using Bookstore.Register;
using Bookstore.Shop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
//in a procces

namespace Bookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Shop.Shop> all_bookstores = new Dictionary<string, Shop.Shop>();
            Dictionary<string, Reader.Reader> all_readers = new Dictionary<string, Reader.Reader>();

            Filler f = new Filler();
            List<Book.Book> books = f.Books();

            //menu
            f.Menu(all_bookstores, all_readers, books);

        }
    }
}
