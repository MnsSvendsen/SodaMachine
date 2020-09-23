using System;
using ConsoleApplication1.Controllers;
using ConsoleApplication1.Moddels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1Tests
{
    [TestClass]
    public class UnitTest1
    {
        SodaMachineController sodaMachine = new SodaMachineController();
        SodaController sodaController = new SodaController();
        [TestMethod]
        public void TestAddCredit()
        { 
            var insertedMoney = "insert 20";
            var exspectedMonney = 20;

            int result = sodaMachine.AddCredit(insertedMoney);

            Assert.AreEqual(exspectedMonney, result);
        }

        [TestMethod]
        public void TestRecallMonney()
        {
            var insertedMoney = 100;
            var exspectedMonney = 0;

            int result = sodaMachine.RecallMonney(insertedMoney);

            Assert.AreEqual(exspectedMonney, result);
        }

        [TestMethod]
        public void OrderSodaTest()
        {

            var inventory = new[] {
            new Soda { Name = "coke", Nr = 5, Price = 20 },
            new Soda { Name = "sprite", Nr = 3, Price = 15 },
             };
            var name = "coke";
            var money = 20;
            sodaController.OrderSoda(name, inventory, money);

            var exspectedNumberOfSodaLeft = 4;

            Assert.AreEqual(inventory[0].Nr, exspectedNumberOfSodaLeft);
        }

        [TestMethod]
        public void OrderSodaSmsTest()
        {

            var inventory = new[] {
            new Soda { Name = "coke", Nr = 5, Price = 20 },
            new Soda { Name = "sprite", Nr = 3, Price = 15 },
             };
            var name = "sprite";
            sodaController.OrderSodaSms(name, inventory);

            var exspectedNumberOfSodaLeft = 2;

            Assert.AreEqual(inventory[1].Nr, exspectedNumberOfSodaLeft);
        }

        [TestMethod]
        public void StockInventoryTest()
        {

            var inventory = new[] {
            new Soda { Name = "coke", Nr = 5, Price = 20 },
            new Soda { Name = "sprite", Nr = 3, Price = 15 },
             };
            var name = "sprite";
            sodaController.StockInventory(name, inventory);

            var MaxStockOfSoda = 6;

            Assert.AreEqual(inventory[1].Nr, MaxStockOfSoda);
        }

        [TestMethod]
        public void PrintInventoryTest()
        {

            var inventory = new[] {
            new Soda { Name = "coke", Nr = 5, Price = 20 },
            new Soda { Name = "sprite", Nr = 3, Price = 15 },
             };
            sodaController.PrintInventory(inventory);

            Assert.IsNotNull(inventory);
        }
    }
}
