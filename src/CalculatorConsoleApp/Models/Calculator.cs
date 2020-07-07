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

       
        private double firstOperand;
        private double secondOperand;
        private string operatorValue;
        private double result = 0;
        public Calculator()
        {

            this.board = new char[][]
        {
            new char[]{'+','-','x',':'},
            new char[] {'9','8','7'},
            new char[] {'6','5','4'},
            new char[] {'3','2','1'},
            new char[] {'0','=','C'}
        };

        }

        public Calculator(double firstOperand, string operatorValue, double secondOperand) : this()
        {
            this.FirstOperand = firstOperand;
            this.OperatorValue = operatorValue;
            this.SecondOperand = secondOperand;

        }



        public double FirstOperand
        {
            get { return this.firstOperand; }
            set
            {

                if (value.GetType().Name != "Double")
                {
                    throw new Exception("No such operand!");
                }
                this.firstOperand = value;
            }
        }

        public string OperatorValue
        {
            get { return operatorValue; }
            set {
                if (value != "+" && value != "-" && value != "*" && value != "/")
                {
                    throw new Exception("No such operator");
                }
                operatorValue = value;
            }
        }

        public double SecondOperand
        {
            get { return this.secondOperand; }
            set
            {

                if (value.GetType().Name != "Double")
                {
                    throw new Exception("No such operand!");
                }
                this.secondOperand = value;
            }
        }


        public char[][] getBoard()
        {
            return this.board;
        }

      

        private double GetResult()
        {
           

            if (this.OperatorValue == "/" && this.SecondOperand == 0)
            {
                throw new Exception("You cant divide by 0 !");
            }
            

           if(this.OperatorValue == "+")
            {
                this.result = this.FirstOperand + this.SecondOperand;
            } else if(operatorValue == "*")
            {
                this.result = this.FirstOperand * this.SecondOperand;
            }
            else if (this.OperatorValue == "-")
            {
                this.result = this.FirstOperand - this.SecondOperand;
            }
            else if (this.OperatorValue == "/")
            {
                this.result = this.FirstOperand / this.SecondOperand;
            }

           

            return result;
        }
        
        public override string ToString()
        {
            string finalToStringResult = $"{this.FirstOperand} {this.OperatorValue} {this.SecondOperand} = {this.GetResult()}";
            
            return finalToStringResult;
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
