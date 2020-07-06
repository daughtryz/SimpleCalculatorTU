using CalculatorConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorConsoleApp.Models
{
    public class Calculator : ICalculator
    {
        private char[][] board;

        private List<string> historyData;
        
        public Calculator()
        {
            this.historyData = new List<string>();

            this.board = new char[][]
        {
            new char[]{'+','-','x',':'},
            new char[] {'9','8','7'},
            new char[] {'6','5','4'},
            new char[] {'3','2','1'},
            new char[] {'0','=','C'}
        };

        }

        public char[][] getBoard()
        {
            return this.board;
        }

        public string GetResult(double firstOperand, string operatorValue, double secondOperand)
        {
            if (operatorValue != "+" && operatorValue != "-" && operatorValue != "*" && operatorValue != "/")
            {
                throw new Exception("No such operator");
            }

            if (operatorValue == "/" && secondOperand == 0)
            {
                throw new Exception("You cant divide by 0 !");
            }
            double result = 0;

           if(operatorValue == "+")
            {
                result = firstOperand + secondOperand;
            } else if(operatorValue == "*")
            {
                result = firstOperand * secondOperand;
            }
            else if (operatorValue == "-")
            {
                result = firstOperand - secondOperand;
            }
            else if (operatorValue == "/")
            {
                result = firstOperand / secondOperand;
            }

            string finalResult = $"{firstOperand} {operatorValue} {secondOperand} = {result}";

            this.historyData.Add(finalResult);

            return finalResult;
        }
        public List<string> GetHistory()
        {

            return this.historyData.OrderByDescending(x => x).ToList();
            
        }
        public void VisualizeBoard()
        {
            for (int i = 0; i < this.board.Length; i++)
            {
                Console.WriteLine("| " + string.Join(" | ",this.board[i]) + " |");
            }
        }
    }
}
