using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main()
        {
            using (TextReader streamReader = new StreamReader("../Resources/text.txt"))
            {
                string inputLine = streamReader.ReadLine();
                int lineCount = 0;
                while (inputLine != null)
                {
                    if (lineCount % 2 != 0)
                    {
                        Console.WriteLine(inputLine);
                    }
                    lineCount++;

                    inputLine = streamReader.ReadLine();
                }
            }
        }
    }
}
