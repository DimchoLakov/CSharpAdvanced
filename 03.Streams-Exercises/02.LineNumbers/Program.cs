using System;
using System.Collections.Generic;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main()
        {
            using (TextReader streamReader = new StreamReader("../Resources/text.txt"))
            {
                using (TextWriter streamWriter = new StreamWriter("../Resources/output.txt"))
                {
                    string lineInput = streamReader.ReadLine();
                    int lineCounter = 1;
                    while (lineInput != null)
                    {
                        lineInput = $"Line {lineCounter}: {lineInput}";

                        lineCounter++;

                        streamWriter.WriteLine(lineInput);

                        lineInput = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
