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
            var inventory = _repo.GetSodas();

            while (true)
            {
                DisplayText();

                var input = Console.ReadLine();

                if (input.StartsWith("insert"))
                {
                    //Add to credit
                    money += int.Parse(input.Split(' ')[1]);
                    Console.WriteLine("Adding " + int.Parse(input.Split(' ')[1]) + " to credit");
                }

                if (input.StartsWith("order"))
                {
                    // split string on space
                    var csoda = input.Split(' ')[1];
                    //Find out witch kind

                    try
                    {
                        var sodatype = inventory.First(Soda => Soda.Name == csoda);
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

                if (input.StartsWith("sms order"))
                {
                    var csoda = input.Split(' ')[2];
                    //Find out witch kind
                    try
                    {
                        var sodatype = inventory.First(Soda => Soda.Name == csoda);
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

                if (input.Equals("recall"))
                {
                    //Give money back
                    Console.WriteLine("Returning " + money + " to customer");
                    money = 0;
                }

            }
        }

        private void DisplayText()
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
