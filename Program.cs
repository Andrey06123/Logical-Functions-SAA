using LogicalLibrary.Functions;
using System;
using LogicalLibrary.DataStructures;
using LogicalLibrary.Models;
using LogicalLibrary.TextProcessing;
using LogicalLibrary.Commands;

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
                case "ALL":
                    All all = new All(input, functionRegistry);
                    all.Execute();
                    break;
                case "FIND":
                    Find find = new Find(input, functionRegistry);
                    List<string> validExpressions = find.Execute();
                    if (validExpressions.Count == 0)
                        Console.WriteLine("There is no valid expression to this table");
                    for(int i = 0; i< validExpressions.Count(); i++)
                        Console.WriteLine(validExpressions[i]);
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}