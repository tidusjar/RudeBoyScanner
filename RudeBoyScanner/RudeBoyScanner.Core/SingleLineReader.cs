using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
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
        private string FileName { get; set; }
        public SingleLineReader(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileNameWithoutExtension(FilePath);
        }

        public List<Record> FindLineNumberAndPosition(string text)
        {
            var offendingLines = new List<Record>();
            var lines = File.ReadLines(FilePath).ToArray();

            Console.WriteLine("Looking for '" + text + "'");

            for (var i = 0; i < lines.Count(); i++)
            {
                if (!lines[i].ToLower().Contains(text.ToLower())) continue;

                var firstPosition = lines[i].IndexOf(text, StringComparison.InvariantCulture);
                
                if (firstPosition <= 0) continue;
                
                offendingLines.Add(new Record()
                {
                    Content = lines[i],
                    LineNumber = (i += 1),
                    File = FileName
                });
            }     

            return offendingLines;
        }
    }
}
