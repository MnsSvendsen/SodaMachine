using ConsoleApplication1.Moddels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Repo
{
    public class MockSodaApi
    {
        public Soda[] GetSodas()
        {
            var inventory = new[] {
            new Soda { Name = "coke", Nr = 5, Price = 20 },
            new Soda { Name = "sprite", Nr = 3, Price = 15 },
            new Soda { Name = "fanta", Nr = 0, Price = 15 }
        };
            return inventory;
        }
    }
}
