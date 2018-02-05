using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();

            Func<string, bool> checkIsFirstLetterCapital = str => char.IsUpper(str[0]);

            string[] words = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Where(checkIsFirstLetterCapital).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
