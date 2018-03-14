using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();

            string textPattern = @"\[[^\s\[\]]+<\d+REGEH\d+>[^\s\]\[]+\]";

            Regex regexText = new Regex(textPattern);

            MatchCollection matches = regexText.Matches(text);

            string numbersPattern = @"<(?<fNum>\d+)REGEH(?<sNum>\d+)>";

            Regex numbersRegex = new Regex(numbersPattern);

            List<int> numbers = new List<int>();

            foreach (Match match in matches)
            {
                MatchCollection numMatches = numbersRegex.Matches(match.Value);

                foreach (Match numMatch in numMatches)
                {
                    numbers.Add(int.Parse(numMatch.Groups["fNum"].Value));
                    numbers.Add(int.Parse(numMatch.Groups["sNum"].Value));
                }
            }

            StringBuilder result = new StringBuilder();

            int index = 0;

            foreach (int number in numbers)
            {
                index += number;
                var symbolIndex = index % (text.Length - 1);
                result.Append(text[symbolIndex]);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
