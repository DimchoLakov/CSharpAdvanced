using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter
{
    class Program
    {
        static void Main()
        {
            int decimalNum = int.Parse(Console.ReadLine());

            Stack<int> binaryStack = new Stack<int>();

            if (decimalNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (decimalNum > 0)
            {
                int remainder = decimalNum % 2;
                binaryStack.Push(remainder);
                decimalNum /= 2;
            }

            while (binaryStack.Count != 0)
            {
                Console.Write(binaryStack.Pop());
            }
        }
    }
}
