using ConsoleApplication1.Moddels;
using ConsoleApplication1.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Controllers
{
    public class SodaMachineController
    {
        private readonly MockSodaApi _repo = new MockSodaApi();
        readonly SodaController sodaController = new SodaController();
        private static int money;
        public SodaMachineController() { }
        /// <summary>
        /// This is the starter method for the machine
        /// </summary>
        public void Start()
        {
            var inventory = _repo.GetSodas();
            while (true)
            {

                DisplayText();


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
                        sodaController.OrderSoda(csoda, inventory, money);
                        ResetMonny();
                    }

                    if (input.StartsWith("sms order"))
                    {
                        var csoda = input.Split(' ')[2];
                        sodaController.OrderSodaSms(csoda, inventory);
                    }
                    if (input.Equals("recall"))
                    {
                        RecallMonney(money);
                    }
                    if (input.Equals("inventory"))
                    {
                        sodaController.PrintInventory(inventory);
                    }
                    if (input.StartsWith("restock"))
                    {
                        var csoda = input.Split(' ')[1];
                        sodaController.StockInventory(csoda, inventory);
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

        public int RecallMonney(int moneyToReturn)
        {
            Console.WriteLine("Returning " + moneyToReturn + " to customer");
            money = 0;
            return money;
        }

        public void ResetMonny()
        {
            money = 0;
        }


        public void DisplayText()
        {
            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine("order (coke, sprite, fanta) - Order from machines buttons");
            Console.WriteLine("sms order (coke, sprite, fanta) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("inventory - Gets inventory in the machin");
            Console.WriteLine("restock (coke, sprite, fanta) - Fully stock inventory");
            Console.WriteLine("-------");
            Console.WriteLine("Inserted money: " + money);
            Console.WriteLine("-------\n\n");
        }
    }

}

