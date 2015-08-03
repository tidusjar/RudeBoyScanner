using System;
using RudeBoyScanner.Core;

namespace RudeBoyScanner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new SingleLineReader(@"File location");
            var lineNumbers = reader.FindLineNumberAndPosition("exclaimer");
            foreach (var number in lineNumbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
