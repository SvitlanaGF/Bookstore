using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Shop
{
    class AdminMenu: Methods_for_menu
    {
        public Shop shop { get; set; }
        public AdminMenu(Shop shop)
        {
            this.shop = shop;
        }

        public void menu(List<Reader.Reader> all_readers)
        {
            Console.WriteLine($"You are in shop: {shop.Name}!");
            Console.WriteLine("Menu:");
            var flag = true;
            while (flag)
            {
                Console.Write("1 - show all books for a shop\n2 - show all readers for a shop\n3 - find a book in a shop\n4 - add book to bookstore\n5 - delete book from bookstore\n7 - delete book from list of books\n8 - find book in list\n-1 - Exit");
                Console.WriteLine("Your Choise : ");
                var choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        show_all_books(shop.GetBooks);
                        break;
                    case 2:
                        show_all_readers_for_the_shop(all_readers);
                        break;
                    case 3:
                        find_book_in(shop.GetBooks);
                        break;
                    case 4:
                        create_and_add_book(this.shop);
                        break;
                    case 5:
                        delete_book(shop.GetBooks);
                        break;


                }
            }
        }

        public void show_all_readers_for_the_shop(List<Reader.Reader> readers)
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
}
