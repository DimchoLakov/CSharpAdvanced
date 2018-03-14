using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class Program
    {
        static void Main()
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] tokens = input
                    .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string[] secondTokens = tokens[1]
                    .Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new Dictionary<string, string>());
                }

                for (int i = 0; i < secondTokens.Length; i += 2)
                {
                    string key = secondTokens[i];
                    string value = secondTokens[i + 1];
                    if (!dict[name].ContainsKey(key))
                    {
                        dict[name].Add(key, value);
                    }
                    else
                    {
                        dict[name][key] = value;
                    }
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();
            string[] killTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string nameToKill = killTokens[1];
            int infoIndex = PrintOutPutAndGetInfoIndex(dict, nameToKill);

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine($"Proceed");
            }
            else
            {
                Console.WriteLine($"Need {Math.Abs(infoIndex - targetInfoIndex)} more info.");
            }

        }

        private static int PrintOutPutAndGetInfoIndex(Dictionary<string, Dictionary<string, string>> dict, string name)
        {
            int index = 0;
            var sorted = dict[name].OrderBy(k => k.Key).ThenBy(v => v.Value).ToDictionary(ke => ke.Key, va => va.Value);
            Console.WriteLine($"Info on {name}:");
            foreach (KeyValuePair<string, string> keyValuePair in sorted)
            {
                index += keyValuePair.Key.Length + keyValuePair.Value.Length;
                Console.WriteLine($"---{keyValuePair.Key}: {keyValuePair.Value}");
            }

            return index;
        }
    }
}
