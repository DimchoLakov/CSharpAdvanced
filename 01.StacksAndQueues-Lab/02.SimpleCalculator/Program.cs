using System;
using System.Collections.Generic;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>();

            Array.Reverse(input);

            foreach (var item in input)
            {
                stack.Push(item);
            }

            while (stack.Count != 1)
            {
                int leftOperand = int.Parse(stack.Pop());
                string op = stack.Pop();
                int rightOperand = int.Parse(stack.Pop());
                int result = 0;
                switch (op)
                {
                    case "+":
                        result = leftOperand + rightOperand;
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        break;
                }
                stack.Push(result.ToString());
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
