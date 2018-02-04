using System;

namespace BashSoft
{
    public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input.Equals(endCommand))
                {
                    break;
                }
                if (string.IsNullOrEmpty(input))
                {
                    input = Console.ReadLine().Trim();
                    continue;
                }
                CommandInterpreter.InterpredCommand(input);
            }
        }
    }
}
