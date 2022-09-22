using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyException;

namespace ExceptionLesson
{
    public class Student
    {
        public Student(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    public class Teacher
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int  Salary { get; set; }
    }

    class Group
    {
        public List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
        public ushort Capacity { get; set; }

        public void AddStudent(Student newStudent)
        {
            if (Capacity == Students.Count)
            {
                throw new StudentException() {HResult = 1, Source = "Out of group capacity"};
            }
            Students.Add(newStudent);
        }
    }
}
