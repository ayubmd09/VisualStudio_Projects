using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_Assignment
{
    // Create an interface named IQuittable.
    interface IQuittable
    {
        // Declare the Quit method.
        void Quit();
    }

    // Employee class implements the IQuittable interface.
    class Employee : IQuittable
    {
        // Property to store the employee's name.
        public string Name { get; set; }

        // Implement the Quit method.
        public void Quit()
        {
            Console.WriteLine(Name + " has quit the company.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an Employee object.
            Employee employee = new Employee();

            // Assign a name to the employee.
            employee.Name = "John";

            // Use polymorphism by creating an interface reference.
            IQuittable quittable = employee;

            // Call the Quit method through the interface.
            quittable.Quit();

            // Keep the console window open until a key is pressed.
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}