using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
            //первый способ
            var allStudents = GetAllStudents1(classes);

            Console.WriteLine(string.Join(" ", allStudents));

            //второй способ
            var allStudents1 = GetAllStudents2(classes);

            Console.WriteLine(string.Join(" ", allStudents1));
        }

        static string[] GetAllStudents1(Classroom[] classes)
        {
            //List<string> st = new List<string>(); 

            //foreach (Classroom cr in classes) 
            //{ 
            //    st.AddRange(cr.Students);                
            //}

            var st = from students in classes
                     from student in students.Students
                     orderby student
                     select student;
                                  
            return st.ToArray();
        }

        static string[] GetAllStudents2(Classroom[] classes)
        {
            
            var st = classes.SelectMany(c => c.Students).OrderBy(s => s);
            return st.ToArray();
        }
        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}