using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsoleApp.Contracts
{
    public interface ICalculator
    {
        string GetResult(double firstOperand,string operatorValue,double secondOperand);

        char[][] getBoard();
        void VisualizeBoard();

        List<string> GetHistory();
    }
}
