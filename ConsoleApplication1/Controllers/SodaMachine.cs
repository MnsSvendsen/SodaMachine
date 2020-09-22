using ConsoleApplication1.Moddels;
using ConsoleApplication1.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Controllers
{
    class SodaMachine
    {
        private readonly MockSodaApi _repo = new MockSodaApi();
        private static int money;
        public SodaMachine() { }
        /// <summary>
        /// This is the starter method for the machine
        /// </summary>
        public void Start()
        {

            while (true)
            {

                DisplayText();

                var inventory = _repo.GetSodas();
                var input = Console.ReadLine();
                try
                {

                    if (input.StartsWith("insert"))
                    {
                        Console.WriteLine("Adding " + AddCredit(input) + " to credit");
                    }


                    if (input.StartsWith("order"))
                    {
                        var csoda = input.Split(' ')[1];
                        OrderSoda(csoda, inventory);
                    }

                    if (input.StartsWith("sms order"))
                    {
                        var csoda = input.Split(' ')[2];
                        OrderSodaSms(csoda, inventory);
                    }
                    if (input.Equals("recall"))
                    {
                        RecallMonney();
                    }
                }
                catch
                {
                    Console.WriteLine(" No such comand ");
                }
            }
        }

        public int AddCredit(string amount)
        {
            money += int.Parse(amount.Split(' ')[1]);
            return money;

        }

        public void OrderSoda(string name, Soda[] inventory)
        {
            try
            {
                var sodatype = inventory.First(Soda => Soda.Name == name);
                if (sodatype.Nr > 0 && sodatype.Price <= money)
                {
                    Console.WriteLine("Giving " + sodatype.Name + " out");
                    money -= sodatype.Price;
                    Console.WriteLine("Giving " + money + " out in change");
                    money = 0;
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

        public void RecallMonney()
        {
            Console.WriteLine("Returning " + money + " to customer");
            money = 0;
        }

        public void DisplayText()
        {
            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine("order (coke, sprite, fanta) - Order from machines buttons");
            Console.WriteLine("sms order (coke, sprite, fanta) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");
            Console.WriteLine("Inserted money: " + money);
            Console.WriteLine("-------\n\n");
        }
    }

}

