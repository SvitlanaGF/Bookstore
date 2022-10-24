using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//to do:
//продумати як використати із паролем все(запис у файл, а коли просто хочемо зайти на ак, то зчитати)
// 

namespace Bookstore.Register
{
    class Reg_Reader:Methods_for_menu
    {
        public void Register(List<Shop.Shop> all_shops, Dictionary<string,Reader.Reader> readers)
        {

            Console.WriteLine("Please, input your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please, input your password:");
            string password = Console.ReadLine();
            Console.WriteLine("Input cash balance:");    //вдосконалити, замінити на введення номера кредитної картки і з файлу по цьому номеру отримаємо інформацію про те, скільки коштів на рахунку
            double cash = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("List of available bookstores:");
            show_all_shops(all_shops);
            Console.WriteLine("Your choise:");
            string choise = Console.ReadLine();
            var shop = all_shops.Where(x => x.Name == choise).FirstOrDefault();
            var reader = readers.Values.Where(x => x.Name == name).FirstOrDefault();
            if(shop != null && name == null)
            {
          
                readers.Add(password, new Reader.Reader(shop, name, cash));
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
            return null;
        }
    }
}
