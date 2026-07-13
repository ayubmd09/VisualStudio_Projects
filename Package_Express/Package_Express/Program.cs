using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package_Express
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome message.
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Ask the user to enter the package weight.
            Console.WriteLine("Please enter the package weight:");
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            // Check if the package is too heavy.
            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return;
            }

            // Ask the user to enter package width.
            Console.WriteLine("Please enter the package width:");
            decimal width = Convert.ToDecimal(Console.ReadLine());

            // Ask the user to input package height.
            Console.WriteLine("Please enter the package height:");
            decimal height = Convert.ToDecimal(Console.ReadLine());

            // input package length.
            Console.WriteLine("Please enter the package length:");
            decimal length = Convert.ToDecimal(Console.ReadLine());

            // Check if the total dimensions are out of range.
            if ((width + height + length) > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return;
            }

            // Logic to calculate the shipping quote.
            decimal quote = (width * height * length * weight) / 100;

            // Display the shipping quote.
            Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("0.00"));

            // Add Thank you at end for the user.
            Console.WriteLine("Thank you!");

            // This line will keep the console window open.
            Console.ReadKey();
        }
    }
}
