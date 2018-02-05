using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main()
        {
            Func<string, double> parseDouble = x => double.Parse(x);
            Func<double, double> addVAT = x => x += x * 0.2;

            List<double> numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parseDouble)
                .Select(addVAT)
                .ToList();

            numbers.ForEach(x => Console.WriteLine($"{x:f2}"));
        }

        //static double DoubleParser(string numberAsString)
        //{
        //    return double.Parse(numberAsString);
        //}
        //
        //static double AddVAT(double number)
        //{
        //    return number + number * 0.2;
        //}
    }
}
