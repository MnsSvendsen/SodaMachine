using ConsoleApplication1.Moddels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Controllers
{
    public class SodaController
    {
        public void OrderSoda(string name, Soda[] inventory, int money)
        {
            try
            {
                var sodatype = inventory.First(Soda => Soda.Name == name);
                if (sodatype.Nr > 0 && sodatype.Price <= money)
                {
                    Console.WriteLine("Giving " + sodatype.Name + " out");
                    money -= sodatype.Price;
                    Console.WriteLine("Giving " + money + " out in change");
                    sodatype.Nr--;
                }
                else if (sodatype.Nr == 0)
                {
                    Console.WriteLine("No " + sodatype.Name + " left");
                }
                else if (sodatype.Price > money)
                {
                    Console.WriteLine("Need " + (sodatype.Price - money) + " more");
                }
            }
            catch
            {
                Console.WriteLine(" No such soda ");
            }
        }

        public void OrderSodaSms(string name, Soda[] inventory)
        {
            try
            {
                var sodatype = inventory.First(Soda => Soda.Name == name);
                if (sodatype.Nr > 0)
                {
                    Console.WriteLine("Giving " + sodatype.Name + " out");
                    sodatype.Nr--;
                }
                else if (sodatype.Nr == 0)
                {
                    Console.WriteLine("No " + sodatype.Name + " left");
                }
            }
            catch
            {
                Console.WriteLine(" No such soda ");
            }
        }
        public void PrintInventory(Soda[] inventory)
        {
            foreach (Soda soda in inventory)
            {
                Console.WriteLine("Name:" + soda.Name + "  Stock:" + soda.Nr + "  Price:" + soda.Price);
            }
        }

        public void StockInventory(string name, Soda[] inventory)
        {
            var sodatype = inventory.First(Soda => Soda.Name == name);
            if (sodatype.Nr < 6)
            {
                Console.WriteLine("Filling " + sodatype.Name + " inn to the machine");
                sodatype.Nr = 6;
            }
            else if (sodatype.Nr >= 6)
            {
                Console.WriteLine("No rom left to stock soda");
            }
        }
    }
}
