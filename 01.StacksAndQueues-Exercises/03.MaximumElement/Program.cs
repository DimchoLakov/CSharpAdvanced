using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main()
        {
            int nQueries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> trackMax = new Stack<int>();
            trackMax.Push(int.MinValue);

            for (int i = 0; i < nQueries; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int query = tokens[0];
                switch (query)
                {
                    case 1:

                        stack.Push(tokens[1]);
                        if (trackMax.Peek() <= tokens[1])
                        {
                            trackMax.Push(tokens[1]);
                        }
                        break;

                    case 2:

                        if (stack.Pop() == trackMax.Peek())
                        {
                            trackMax.Pop();
                        }
                        break;

                    case 3:

                        Console.WriteLine(trackMax.Peek());
                        break;

                }
            }
        }
    }
}
