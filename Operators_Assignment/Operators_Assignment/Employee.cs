using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators_Assignment
{
    internal class Employee
    {
        // Employee Id property.
        public int Id { get; set; }

        // Employee first name property.
        public string FirstName { get; set; }

        // Employee last name property.
        public string LastName { get; set; }

        // Overload the == operator.
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.Id == emp2.Id;
        }

        // Overload the != operator.
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return emp1.Id != emp2.Id;
        }
    }
}