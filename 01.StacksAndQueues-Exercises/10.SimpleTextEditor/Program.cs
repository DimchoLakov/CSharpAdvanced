using System;
using System.Collections.Generic;
using System.Text;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");

            Stack<string> stack = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(tokens[0]);

                switch (command)
                {
                    case 1:
                        string strToAppend = tokens[1];
                        AppendAtEndOfString(sb, strToAppend, stack);
                        break;
                    case 2:
                        int charsCountToDelete = int.Parse(tokens[1]);
                        EraseLastNChars(sb, charsCountToDelete, stack);
                        break;
                    case 3:
                        int index = int.Parse(tokens[1]);
                        ReturnElementAtIndex(sb, index);
                        break;
                    case 4:
                        UndoLastOperation(sb, stack);
                        break;
                }
            }
        }

        static void UndoLastOperation(StringBuilder sb, Stack<string> stack)
        {
            sb.Clear();
            sb.Append(stack.Pop());
        }

        static void ReturnElementAtIndex(StringBuilder sb, int index)
        {
            Console.WriteLine(sb[index - 1]);
        }

        static void EraseLastNChars(StringBuilder sb, int charsCountToDelete, Stack<string> stack)
        {
            stack.Push(sb.ToString());
            int startIndex = (sb.Length) - charsCountToDelete;
            sb.Remove(startIndex, charsCountToDelete);
        }

        static void AppendAtEndOfString(StringBuilder sb, string strToAppend, Stack<string> stack)
        {
            stack.Push(sb.ToString());
            sb.Append(strToAppend);
        }
    }
}
