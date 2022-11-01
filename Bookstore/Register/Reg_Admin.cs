using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bookstore.Register
{
    class Reg_Admin
    {
        public void Register(Dictionary<string, Shop.Shop> all_shops)
        {
            Console.WriteLine("Please, write bookstore name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please, write password:");
            string password = Console.ReadLine();
            var bookstore = all_shops.Values.Where(x => x.Name == name).FirstOrDefault();
            if (bookstore == null && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$") == true)
            {
                all_shops.Add(password, new Shop.Shop(name));
                Console.WriteLine($"The bookstore '{name}' has been added");
            }
            else
            {
                Console.WriteLine("This bookstore exists");
            }
        }
        public Shop.Shop LogIn(Dictionary<string, Shop.Shop> all_shops){
            Console.WriteLine("Please, write bookstore name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please, write password:");
            string password = Console.ReadLine();
            var passw = all_shops.Keys.Where(x => x == password).FirstOrDefault();
            if (passw != null && all_shops[passw].Name == name)
            {
                return all_shops[passw];
            }
            else
            {
                Console.WriteLine("This bookstore doen't exist");
                return null;
            }
        }

        public Shop.Shop RegMenu(Dictionary<string, Shop.Shop> all_shops)
        {
            Console.WriteLine("Register(R) or Log In(L)?");
            string choise = Console.ReadLine();
            if(choise.ToLower() == "r" || choise.ToLower() == "register")
            {
                this.Register(all_shops);
                return this.LogIn(all_shops);

            }
            else if(choise.ToLower() == "l" || choise.ToLower() == "login")
            {
                return this.LogIn(all_shops);
            }
            return null;
        }
    }
}
