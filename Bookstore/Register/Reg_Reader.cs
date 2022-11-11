using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Register
{
    class Reg_Reader:Methods_for_menu
    {
        public Reader.Reader Register(List<Shop.Shop> all_shops, Dictionary<string,Reader.Reader> readers) // 
        {

            Console.WriteLine("Please, input your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please, input your password:");
            string password = Console.ReadLine();
            Console.WriteLine("Input cash balance:");    //вдосконалити, замінити на введення номера кредитної картки і з файлу по цьому номеру отримаємо інформацію про те, скільки коштів на рахунку
            string cash = Console.ReadLine();
            Console.WriteLine("List of available bookstores:");
            show_all_shops(all_shops);
            Console.WriteLine("Your choise (number of a bookstore):");
            int choise = Convert.ToInt32(Console.ReadLine());
            var reader = readers.Values.Where(x => x.Name == name).FirstOrDefault();
            if(choise >= 1 && choise <= all_shops.Count+1 && reader == null && double.TryParse(cash, out double csh) && csh >=0)
            {
                readers.Add(password, new Reader.Reader(all_shops[choise-1], name, csh));
                Console.WriteLine("Please, input your data again");
                return LogIn(readers);
            }
            else
            {
                Console.WriteLine("Incorrect data");
                Console.WriteLine("Try again!");
                return Register(all_shops, readers);
            }
        }
        public Reader.Reader LogIn(Dictionary<string, Reader.Reader> readers)
        {
            Console.WriteLine("Please, input your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please, input your password:");
            string password = Console.ReadLine();
            var passw = readers.Keys.Where(x => x == password).FirstOrDefault();
            if(passw != null && readers[passw].Name == name)
            {
                return readers[passw];
            }
            Console.WriteLine("We can't find the user");
            Console.WriteLine("Try again!");
            return LogIn(readers);
        }

        public Reader.Reader RegMenu(List<Shop.Shop> all_shops, Dictionary<string, Reader.Reader> readers)
        {
            Console.WriteLine("Register(R) or Log In(L)?");
            string choise = Console.ReadLine();
            if(choise.ToLower() == "r" || choise.ToLower() == "register")
            {
                Register(all_shops, readers);
            }else if(choise.ToLower() == "l" || choise.ToLower() == "login")
            {
                return LogIn(readers);
            }
            return null;
        }

    }
}
