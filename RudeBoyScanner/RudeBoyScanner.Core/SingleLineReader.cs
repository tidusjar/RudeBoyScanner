using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RudeBoyScanner.Core
{
    public class SingleLineReader
    {
        private string FilePath { get; set; }
        public SingleLineReader(string filePath)
        {
            FilePath = filePath;
        }

        public List<string> FindLineNumberAndPosition(string text)
        {
            var offendingLines = new List<string>();
            var lines = File.ReadLines(FilePath).ToArray();

            Console.WriteLine("Looking for '" + text + "'");

            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].ToLower().Contains(text.ToLower()))
                {
                    var lineContent = lines[i];
                    var firstPosition = lines[i].IndexOf(text, StringComparison.InvariantCulture);
                    if (firstPosition > 0)
                    {
                        var word = lines[i].Substring(firstPosition, text.Length);
                         offendingLines.Add("Line Number: " + (i += 1) + " Position: " + firstPosition + " Word: " + word);
                    }
                }
            }     

            return offendingLines;
        }
    }
}
