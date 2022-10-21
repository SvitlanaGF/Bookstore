using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//to do:
//comments  

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
                        Console.WriteLine("Shop:");
                        string srch = Console.ReadLine();
                        Console.WriteLine(">>>>>>>>>>Books<<<<<<<<<<");
                        var shop = all_shops.Where(x => x.Name == srch).FirstOrDefault();
                        if (shop != null)
                        {
                            show_all_books(shop.GetBooks);
                        }
                            Console.WriteLine("Do you want buy a book from this list?(Y/N)");
                            string answ = Console.ReadLine();
                            if (answ.ToLower() == "y")
                            {
                                Console.WriteLine("Title:");
                                string ttl = Console.ReadLine();
                                Console.WriteLine("Author:");
                                string ath = Console.ReadLine();
                                var book = shop.GetBooks.Where(x => x.Title == ttl && x.Author == ath).FirstOrDefault();
                                if (book != null)
                                {
                                    buy_book(book, rdr);
                                }

                            }
                            else if (answ.ToLower() == "n")
                            {
                                Console.WriteLine("Ok:(");
                            }
                        else
                        {
                            Console.WriteLine("We can't find it:(");
                        }
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
