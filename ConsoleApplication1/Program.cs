using ConsoleApplication1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
       
        private static void Main(string[] args)
        {
            SodaMachineController sodaMachine = new SodaMachineController();
            sodaMachine.Start();
        }
    }   
}
