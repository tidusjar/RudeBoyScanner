using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudeBoyScanner.Core;

namespace RudeBoyScanner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new SingleLineReader(@"filepath");
            var lineNumbers = reader.FindLineNumberAndPosition("exclaimer");
            foreach (var number in lineNumbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
