using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main()
        {
            HashSet<string> wordsToSearchFor = new HashSet<string>();
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (TextWriter streamWriter = new StreamWriter("../Resources/words.txt"))
            {
                streamWriter.WriteLine("quick");
                streamWriter.WriteLine("is");
                streamWriter.WriteLine("fault");
            }
            using (TextReader streamReader = new StreamReader("../Resources/words.txt"))
            {
                string inputWord = streamReader.ReadLine();

                while (inputWord != null)
                {
                    wordsToSearchFor.Add(inputWord.ToLower());

                    inputWord = streamReader.ReadLine();
                }
            }

            string wordPattern = @"\w+";
            Regex wordsRegex = new Regex(wordPattern);

            using (TextReader streamReader = new StreamReader("../Resources/text.txt"))
            {
                string inputLine = streamReader.ReadLine();

                while (inputLine != null)
                {
                    MatchCollection matches = wordsRegex.Matches(inputLine);

                    foreach (Match match in matches)
                    {
                        string word = match.ToString().ToLower();
                        if (wordsToSearchFor.Contains(word))
                        {
                            if (!wordsCount.ContainsKey(word))
                            {
                                wordsCount.Add(word, 1);
                            }
                            else
                            {
                                wordsCount[word]++;
                            }
                        }
                    }

                    inputLine = streamReader.ReadLine();
                }
            }
            wordsCount = wordsCount.OrderByDescending(w => w.Value).ToDictionary(k => k.Key, v => v.Value);

            using (TextWriter streamWriter = new StreamWriter("../Resources/result.txt"))
            {
                foreach (KeyValuePair<string, int> wordCountPair in wordsCount)
                {
                    streamWriter.WriteLine($"{wordCountPair.Key} - {wordCountPair.Value}");
                }
            }
        }
    }
}
