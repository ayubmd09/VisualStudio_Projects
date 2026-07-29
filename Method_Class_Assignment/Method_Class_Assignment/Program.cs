using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Class_Assignment
{
    // This class contains a method that performs a math operation.
    internal class MathOperations
    {
        // This method accepts two integer parameters.
        public void DoMath(int firstNumber, int secondNumber)
        {
            // Multiply the first number by 2.
            int result = firstNumber * 2;

            // Display the result of the math operation.
            Console.WriteLine("Result of first number × 2: " + result);

            // Display the second number.
            Console.WriteLine("Second Number: " + secondNumber);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an object of the MathOperations class.
            MathOperations math = new MathOperations();

            // Call the method by passing two numbers.
            math.DoMath(10, 20);

            Console.WriteLine();

            // Call the method using named parameters.
            math.DoMath(firstNumber: 15, secondNumber: 30);

            // Keep the console window open.
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}