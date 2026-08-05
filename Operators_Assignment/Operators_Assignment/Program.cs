using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the first Employee object.
            Employee emp1 = new Employee();
            emp1.Id = 1;
            emp1.FirstName = "Ayub";
            emp1.LastName = "M";

            // Create the second Employee object.
            Employee emp2 = new Employee();
            emp2.Id = 2;
            emp2.FirstName = "Robert";
            emp2.LastName = "Jr";

            // Compare the two Employee objects using the overloaded == operator.
            if (emp1 == emp2)
            {
                Console.WriteLine("The employees are equal.");
            }
            else
            {
                Console.WriteLine("The employees are not equal.");
            }

            // Keep the console window open.
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}