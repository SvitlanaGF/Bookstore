using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bookstore.Register
{
    class Reg_Reader:Methods_for_menu
    {
        public void Register(List<Shop.Shop> all_shops, List<Reader.Reader> readers)
        {

            Console.WriteLine("Please, input your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Input cash balance:");    //вдосконалити, замінити на введення номера кредитної картки і з файлу по цьому номеру отримаємо інформацію про те, скільки коштів на рахунку
            double cash = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("List of available bookstores:");
            show_all_shops(all_shops);
            Console.WriteLine("Your choise:");
            string choise = Console.ReadLine();
            var shop = all_shops.Where(x => x.Name == choise).FirstOrDefault();
            if(shop != null)
            {
                readers.Add(new Reader.Reader(shop, name, cash));
            }
        }
    }
}
