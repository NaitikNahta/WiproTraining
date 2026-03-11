using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CalculatorLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        // Runs before each test — initializes a fresh Calculator instance
        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        // ─── ADD ────────────────────────────────────────────────

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            double result = _calculator.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Add_NegativeNumbers_ReturnsCorrectSum()
        {
            double result = _calculator.Add(-4, -6);
            Assert.AreEqual(-10, result);
        }

        [Test]
        public void Add_WithZero_ReturnsSameNumber()
        {
            double result = _calculator.Add(7, 0);
            Assert.AreEqual(7, result);
        }

        // ─── SUBTRACT ───────────────────────────────────────────

        [Test]
        public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
        {
            double result = _calculator.Subtract(10, 4);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Subtract_WithZero_ReturnsSameNumber()
        {
            double result = _calculator.Subtract(5, 0);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Subtract_SameNumbers_ReturnsZero()
        {
            double result = _calculator.Subtract(9, 9);
            Assert.AreEqual(0, result);
        }

        // ─── MULTIPLY ───────────────────────────────────────────

        [Test]
        public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            double result = _calculator.Multiply(4, 5);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Multiply_ByZero_ReturnsZero()
        {
            double result = _calculator.Multiply(100, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Multiply_NegativeNumbers_ReturnsPositiveProduct()
        {
            double result = _calculator.Multiply(-3, -4);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Multiply_PositiveAndNegative_ReturnsNegativeProduct()
        {
            double result = _calculator.Multiply(5, -2);
            Assert.AreEqual(-10, result);
        }

        // ─── DIVIDE ─────────────────────────────────────────────

        [Test]
        public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
        {
            double result = _calculator.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Assert.Throws verifies that the correct exception is thrown
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Test]
        public void Divide_NegativeDividend_ReturnsNegativeQuotient()
        {
            double result = _calculator.Divide(-10, 2);
            Assert.AreEqual(-5, result);
        }

        [Test]
        public void Divide_ZeroDividend_ReturnsZero()
        {
            double result = _calculator.Divide(0, 5);
            Assert.AreEqual(0, result);
        }
    }
}
