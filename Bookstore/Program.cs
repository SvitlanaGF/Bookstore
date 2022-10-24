using Bookstore.Reader;
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
            Filler f = new Filler();
            List<Book.Book> books = f.Books();
            List<Shop.Shop> bookstores = f.Shops();
            List<Reader.Reader> readers = new List<Reader.Reader>();
            Reader.Reader rdr = new Reader.Reader(bookstores[0],"First", 12708);
            readers.Add(rdr);
            ReaderMenu rdrm = new ReaderMenu(rdr);

            rdrm.menu(bookstores);
            AdminMenu adminMenu = new AdminMenu(bookstores[0]);
            adminMenu.menu(readers, books);
        }
    }
}
