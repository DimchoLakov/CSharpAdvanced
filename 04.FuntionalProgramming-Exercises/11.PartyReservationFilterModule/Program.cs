using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (!input.Equals("Print"))
            {
                string[] tokens = input
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                string filter = tokens[0];
                string filterType = tokens[1];
                string parameter = tokens[2];

                if (filter == "Add filter")
                {
                    filters.Add(filterType + " " + parameter);
                }
                else if (filter == "Remove filter")
                {
                    filters.Remove(filterType + " " + parameter);
                }
                input = Console.ReadLine();
            }
            names = FilterNames(names, filters);

            if (names.Count != 0)
            {
                Console.WriteLine(string.Join(" ", names));
            }
        }

        static List<string> FilterNames(List<string> names, List<string> filters)
        {
            foreach (string filter in filters)
            {
                List<string> commands = filter.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                string command = commands[0];

                switch (command)
                {
                    case "Starts":
                        names = names.Where(name => !name.StartsWith(commands[2])).ToList();
                        break;
                    case "Ends":
                        names = names.Where(name => !name.EndsWith(commands[2])).ToList();
                        break;
                    case "Length":
                        names = names.Where(name => name.Length != int.Parse(commands[1])).ToList();
                        break;
                    case "Contains":
                        names = names.Where(name => !name.Contains(commands[1])).ToList();
                        break;
                }
            }
            return names;
        }
    }
}
