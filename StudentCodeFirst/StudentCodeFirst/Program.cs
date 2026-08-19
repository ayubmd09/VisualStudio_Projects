using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                // Check whether a student already exists
                if (!context.Students.Any())
                {
                    var student = new Student
                    {
                        FirstName = "John",
                        LastName = "Smith"
                    };

                    context.Students.Add(student);
                    context.SaveChanges();

                    Console.WriteLine("Student added successfully!");
                    Console.WriteLine("Student ID: " + student.StudentId);
                    Console.WriteLine("Name: " + student.FirstName + " " + student.LastName);
                }
                else
                {
                    Console.WriteLine("A student already exists in the database.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
