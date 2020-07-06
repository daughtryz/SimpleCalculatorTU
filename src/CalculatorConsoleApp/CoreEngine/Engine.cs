using CalculatorConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorConsoleApp.CoreEngine
{
    public class Engine : IEngine
    {
        private readonly ICalculator calculator;

        public Engine(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        public void Run()
        {
            calculator.VisualizeBoard();
            Console.WriteLine("Input three parameters: firstOperand,operator and secondOperand!");
            Console.WriteLine("Press h to view your history input!");
            Console.WriteLine("Press y if you want to stop the program!");
            while (true)
            {
                string input = Console.ReadLine();

                if(input == "y")
                {
                    break;
                }
                string[] args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(args.Length != 3 && input != "h")
                {
                    throw new Exception("Invalid input operators!");
                }
               
                if(input == "h")
                {
                    if(this.calculator.GetHistory().Count > 0)

                    {
                        Console.WriteLine("Your history calculations:");
                        Console.WriteLine(string.Join("\n", this.calculator.GetHistory()));
                        continue;
                    } else
                    {
                        Console.WriteLine("No history found");
                        continue;
                    }
                    
                }         

               
                bool allLettersFromFirstOperand = args[0].All(c => Char.IsLetter(c));
                bool allLettersFromSecondOperand = args[2].All(c => Char.IsLetter(c));

                if (allLettersFromFirstOperand || allLettersFromSecondOperand)
                {
                    throw new Exception("No such operand!");
                } else if(allLettersFromFirstOperand && allLettersFromSecondOperand)
                {
                    throw new Exception("No such operand!");
                }
                
                int firstOperand = int.Parse(args[0]);

                string operatorValue = args[1];

                int secondOperand = int.Parse(args[2]);

               

                string result = calculator.GetResult(firstOperand, operatorValue, secondOperand);

                Console.WriteLine(result);
            }
       
        }
    }
}
