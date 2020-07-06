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
            
            Assert.AreEqual(expectedResult, this.calculator.GetResult(1, "+", 1));
        }
        [Test]
        public void TestIfGetResultMethodWorksWhenSubtract()
        {
            
            var expectedResult = $"{2} - {1} = {1}";

            Assert.AreEqual(expectedResult, this.calculator.GetResult(2, "-", 1));
        }

        [Test]
        public void TestIfGetResultMethodWorksWhenMultiply()
        {
            
            var expectedResult = $"{2} * {1} = {2}";

            Assert.AreEqual(expectedResult, this.calculator.GetResult(2, "*", 1));
        }

        [Test]
        public void TestIfGetResultMethodWorksWhenDivide()
        {
            
            var expectedResult = $"{5} / {2} = {2.5}";

            Assert.AreEqual(expectedResult, this.calculator.GetResult(5, "/", 2));
        }
        [Test]
        public void TestIfGetResultThrowsExceptionWhenInvalidOperator()
        {
            Assert.Throws<Exception>(() => this.calculator.GetResult(1, "_", 1));
        }

        [Test]
        public void TestIfGetResultThrowsExWhenDivisionAndSecondOperatorEqualToZero()
        {
            Assert.Throws<Exception>(() => this.calculator.GetResult(2, "/", 0));
        }

        [Test]
        public void TestIfHistoryDataListWorks()
        {
            var expectedCount = 2;
            this.calculator.GetResult(2, "*", 2);
            this.calculator.GetResult(3, "+", 2);

            Assert.AreEqual(expectedCount, this.calculator.GetHistory().Count);
        }

    }
}