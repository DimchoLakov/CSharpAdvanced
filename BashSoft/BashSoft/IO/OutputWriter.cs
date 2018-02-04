using System;
using System.Collections.Generic;

namespace BashSoft
{
    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentConsoleColor;
        }

        public static void DisplayStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteMessageOnNewLine(string.Format($"{student.Key} - {string.Join(", ", student.Value)}"));
        }
    }
}
