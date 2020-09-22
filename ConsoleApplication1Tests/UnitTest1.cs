using System;
using ConsoleApplication1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication1Tests
{
    [TestClass]
    public class UnitTest1
    {
        SodaMachine sodaMachine = new SodaMachine();
        [TestMethod]
        public void TestAddCredit()
        { 
            var insertedMoney = "insert 20";
            var exspectedMonney = 20;

            int result = sodaMachine.AddCredit(insertedMoney);

            Assert.AreEqual(exspectedMonney, result);
        }
    }
}
