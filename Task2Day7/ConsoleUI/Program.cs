using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Fibonacci.FibonacciSequence())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
