using CalculatorConsoleApp.Contracts;
using CalculatorConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorConsoleApp.CoreEngine
{
    public class Engine : IEngine
    {
        private ICalculator calculator;
        private double firstOperand;
        private double secondOperand;
        private string operatorValue;
        private List<ICalculator> calculators;
        public Engine(ICalculator calculator)
        {
            this.calculator = calculator;
            this.calculators = new List<ICalculator>();
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
                    if(this.calculators.Count > 0)

                    {
                        Console.WriteLine("Your history calculations:");
                        

                        foreach (var calc in this.calculators)
                        {
                            Console.WriteLine(calc.ToString());
                        }
                        continue;
                    } else
                    {
                        Console.WriteLine("No history found");
                        continue;
                    }
                    
                }
       
               
                if(!double.TryParse(args[0], out this.firstOperand) || !double.TryParse(args[2], out this.secondOperand))
                {
                    throw new ArgumentException("Invalida data");
                }
                      

                this.operatorValue = args[1];

                 this.calculator = new Calculator(this.firstOperand, this.operatorValue, this.secondOperand);
                this.calculators.Add(this.calculator);
                string result = calculator.ToString();
                Console.WriteLine(result);
            }
       
        }
    }
}
