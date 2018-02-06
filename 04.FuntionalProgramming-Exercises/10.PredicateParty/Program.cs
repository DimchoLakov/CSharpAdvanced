using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, string, bool> isInPartyList = CheckPartyList(people);

            string command = Console.ReadLine();

            while (!command.Equals("Party!"))
            {
                string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string removeOrAdd = tokens[0];
                string action = tokens[1];
                string parameter = tokens[2];

                if (removeOrAdd.Equals("Remove"))
                {
                    if (isInPartyList(action, parameter))
                    {
                        if (action.Equals("StartsWith"))
                        {
                            people.RemoveAll(x => x.StartsWith(parameter));
                        }
                        else if (action.Equals("EndsWith"))
                        {
                            people.RemoveAll(x => x.EndsWith(parameter));
                        }
                        else if (action.Equals("Length"))
                        {
                            people.RemoveAll(x => x.Length == int.Parse(parameter));
                        }
                    }
                }
                else if (removeOrAdd.Equals("Double"))
                {
                    if (isInPartyList(action, parameter))
                    {
                        if (action.Equals("StartsWith"))
                        {
                            var temp = people.Where(x => x.StartsWith(parameter)).ToList();
                            for (int i = 0; i < temp.Count; i++)
                            {
                                people.Add(temp[i]);
                            }
                        }
                        else if (action.Equals("EndsWith"))
                        {
                            if (action.Equals("EndsWith"))
                            {
                                var temp = people.Where(x => x.EndsWith(parameter)).ToList();
                                for (int i = temp.Count - 1; i >= 0; i--)
                                {
                                    people.Add(temp[i]);
                                }
                            }
                        }
                        else if (action.Equals("Length"))
                        {
                            if (action.Equals("Length"))
                            {
                                int strLength = int.Parse(parameter);
                                var temp = people.Where(x => x.Length == strLength).ToList();
                                for (int i = temp.Count - 1; i >= 0; i--)
                                {
                                    people.Add(temp[i]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    command = Console.ReadLine();
                    continue;
                }

                command = Console.ReadLine();
            }
            
            if (people.Count != 0)
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
            
        }

        static Func<string, string, bool> CheckPartyList(List<string> people)
        {
            return (string command, string param) =>
            {
                switch (command)
                {
                    case "StartsWith":
                        return people.Any(x => x.StartsWith(param));
                        break;
                    case "EndsWith":
                        return people.Any(x => x.EndsWith(param));
                        break;
                    case "Length":
                        return people.Any(x => x.Length == int.Parse(param));
                        break;
                    default:
                        throw new NotImplementedException();
                        break;
                }
            };
        }
    }
}
