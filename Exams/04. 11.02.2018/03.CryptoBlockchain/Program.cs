using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
            }

            string stringToSearch = sb.ToString();

            string pattern =
                @"(\{[^\[\]\{\}]*?(?<dig>\d{3,})[^\{\}\[\]]*?\})|\[[^\[\]\{\}]*?(?<dig>\d{3,})[^\{\}\[\]]*?\]";
            

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(stringToSearch);
            StringBuilder result = new StringBuilder();
            foreach (Match match in matches)
            {
                string numsAsStr = match.Groups["dig"].Value;
                if (numsAsStr.Length % 3 == 0)
                {
                    List<char> toPrint = new List<char>();

                    for (int i = 0; i < numsAsStr.Length; i += 3)
                    {
                        List<char> nums = new List<char> { numsAsStr[i], numsAsStr[i + 1], numsAsStr[i + 2] };

                        char[] tempArr = nums.Take(3).ToArray();

                        int num = int.Parse(new string(tempArr));
                        num -= match.Value.Length;
                        result.Append((char) num);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
