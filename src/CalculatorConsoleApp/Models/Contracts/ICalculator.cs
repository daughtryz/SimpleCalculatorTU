using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsoleApp.Contracts
{
    public interface ICalculator
    {

        char[][] getBoard();
        void VisualizeBoard();

    }
}
