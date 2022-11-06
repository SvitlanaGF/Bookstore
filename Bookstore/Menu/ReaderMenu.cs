using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//to do:
//comments  
//

namespace Bookstore.Reader
{
    class ReaderMenu: Methods_for_menu
    {
        public Reader rdr { get; set; }
        public ReaderMenu(Reader rdr)
        {
            this.rdr = rdr;
        }

        public void menu(List<Shop.Shop> all_shops)
        {
            Console.WriteLine($"Hi {rdr.Name}!");
            Console.WriteLine("Menu:");
            var flag = true;
            while (flag)
            {
                Console.Write("1 - show all shops\n2 - show all books for a shop\n3 - find a book in shops\n4 - show all books for a reader\n5 - add book to list of favourites\n6 - delete book from favourites\n7 - delete book from list of books\n8 - find book in list\n9 - find book in list of favourites\n-1 - Exit");
                Console.WriteLine("Your Choise : ");
                var choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        show_all_shops(all_shops);
                        break;
                    case 2:
                        show_all_books_for_a_bookstore(all_shops, rdr);
                        break;
                    case 3:
                        find_a_book_in_bookstores(all_shops, rdr);
                        break;
                    case 4:
                        show_all_books(rdr.UsrBooks);
                        break;
                    case 5:
                        add_book(rdr.FavBooks, rdr.UsrBooks);
                        break;
                    case 6:
                        delete_book(rdr.FavBooks);
                        break;
                    case 7:
                        delete_book(rdr.UsrBooks);
                        break;
                    case 8:
                        find_book_in(rdr.UsrBooks);
                        break;
                    case 9:
                        find_book_in(rdr.FavBooks);
                        break;
                    case -1: 
                        flag = false; 
                        Console.WriteLine("GoodBye!"); 
                        break;
                    default:
                        break;
                }
            }
        }

       
        

    }
}
