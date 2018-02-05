using System;
using System.Collections.Generic;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Func<string, int> intParser = x => int.Parse(x);

            Dictionary<string, int> people = new Dictionary<string, int>(n);

            for (int i = 0; i < n; i++)
            {
                string[] nameAndAge = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string name = nameAndAge[0];
                int age = intParser(nameAndAge[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }
                else
                {
                    people[name] = age;
                }
            }

            string condition = Console.ReadLine();
            int ageToFilter = intParser(Console.ReadLine());
            string nameAgeToFilter = Console.ReadLine();

            var filter = CreateFilter(condition, ageToFilter);
            var printer = CreatePrinter(nameAgeToFilter);

            foreach (KeyValuePair<string, int> personNameAgePair in people)
            {
                if (filter(personNameAgePair.Value))
                {
                    printer(personNameAgePair);
                }
            }
        }

        static Func<int, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            return x => x >= age;
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string inputFormat)
        {
            switch (inputFormat)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    return x => Console.WriteLine($"Invalid format");
            }
        }
    }
}
