using LogicalLibrary.Functions;
using System;
using LogicalLibrary.DataStructures;
using LogicalLibrary.Models;
using LogicalLibrary.TextProcessing;

namespace Logic_SAA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FunctionRegistry functionRegistry = new FunctionRegistry();
            while (true)
            {
                Console.WriteLine("Enter a function (or type 'exit' to quit):");
                string? input = Console.ReadLine();
                if (input == "exit")
                    break;
                CommandSwitch(input, functionRegistry);
            }
        }
        static void CommandSwitch(string input, FunctionRegistry functionRegistry)
        {
            switch (ElementsSearch.GetTheElementsToChar(input,' ').ToUpper())
            {
                case "DEFINE":
                    Function function = new Function(input, functionRegistry);
                    functionRegistry.Add(function);
                    break;
                case "SOLVE":
                    Solve solve = new Solve(input, functionRegistry);
                    Console.WriteLine($"Result: {solve.Execute()}");
                    break;
                case "FIND":
                    Console.WriteLine("Simplify function called.");
                    break;
                case "ALL":
                    Console.WriteLine("All functions called.");
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}