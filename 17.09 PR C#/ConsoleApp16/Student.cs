using DeserializeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Student:Person
    {
        public int semester;
        public float gpa { get; set; }

        public override string ToString()
        {
            return $"Name - {name}\n" +
                   $"Surname - {surname}\n" +
                   $"Age - {age}\n" +
                   $"Semester - {semester}\n" +
                   $"GPA - {gpa}\n";
        }
    }
}
