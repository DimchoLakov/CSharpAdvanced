using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            string pattern = @"(\#[^!#]*?(?<![a-zA-Z0-9])(?<str>[a-zA-Z]{4})(?![a-zA-Z]|\d)[^!#]*(?<!\d)(?<num>\d{3})-(?<pass>\d{4}|\d{6})(?!\d)[^!#]*?\!)|(\![^!#]*?(?<![a-zA-Z0-9])(?<str>[a-zA-Z]{4})(?![a-zA-Z]|\d)[^!#]*(?<!\d)(?<num>\d{3})-(?<pass>\d{4}|\d{6})(?!\d)[^!#]*?\#)";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = regex.Matches(input);

                int index = matches.Count / 2;
                Match match = matches[index];
                sb.AppendLine(
                    $"Go to str. {match.Groups["str"]} {match.Groups["num"]}. Secret pass: {match.Groups["pass"]}.");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
