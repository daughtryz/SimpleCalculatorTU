using CalculatorConsoleApp.Contracts;
using CalculatorConsoleApp.CoreEngine;
using CalculatorConsoleApp.Models;
using System;

namespace CalculatorConsoleApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();
            IEngine engine = new Engine(calculator);

            engine.Run();
        }
    }
}
