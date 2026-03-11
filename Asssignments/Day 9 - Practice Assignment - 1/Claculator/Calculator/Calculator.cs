using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLibrary
{
    public class Calculator
    {
        /// <summary>Adds two numbers.</summary>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>Subtracts b from a.</summary>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>Multiplies two numbers.</summary>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>Divides a by b. Throws DivideByZeroException if b is 0.</summary>
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");

            return a / b;
        }
    }
}
