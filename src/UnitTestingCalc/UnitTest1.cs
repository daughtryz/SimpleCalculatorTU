using CalculatorConsoleApp.Contracts;
using CalculatorConsoleApp.CoreEngine;
using CalculatorConsoleApp.Models;
using NUnit.Framework;
using System;

namespace UnitTestingCalc
{
    public class Tests
    {
        private ICalculator calculator;
        
        [SetUp]
        public void Setup()
        {
            this.calculator = new Calculator();
            
        }

        [Test]
        public void TestIfGetResultMethodWorksWhenAdd()
        {
           
            var expectedResult = $"{1} + {1} = {2}";
            this.calculator = new Calculator(1, "+", 1);
            Assert.AreEqual(expectedResult, this.calculator.ToString());
        }
        [Test]
        public void TestIfGetResultMethodWorksWhenSubtract()
        {
            
            var expectedResult = $"{2} - {1} = {1}";
            this.calculator = new Calculator(2, "-", 1);
            Assert.AreEqual(expectedResult, this.calculator.ToString());
        }

        [Test]
        public void TestIfGetResultMethodWorksWhenMultiply()
        {
            
            var expectedResult = $"{2} * {1} = {2}";
            this.calculator = new Calculator(2, "*", 1);
            Assert.AreEqual(expectedResult, this.calculator.ToString());
        }

        [Test]
        public void TestIfGetResultMethodWorksWhenDivide()
        {
            
            var expectedResult = $"{5} / {2} = {2.5}";
            this.calculator = new Calculator(5, "/", 2);
            Assert.AreEqual(expectedResult, this.calculator.ToString());
        }
       
        [Test]
        public void TestIfGetResultThrowsExWhenDivisionAndSecondOperatorEqualToZero()
        {
            this.calculator = new Calculator(5, "/", 0);
            Assert.Throws<Exception>(() => this.calculator.ToString());
        }

        [Test]
        public void TestIfOperatorThrowsException()
        {
            
            Assert.Throws<Exception>(() => this.calculator = new Calculator(5, "_", 2));
        }

       


    }
}