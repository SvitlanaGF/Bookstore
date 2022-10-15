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
            string folder = @"D:\Lessons\L2\Bookstore\Bookstore\Books";
            string fileName = "Books.json";
            string fullPath = folder + fileName;
            List<Book.Book> all_books = new List<Book.Book>();
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
