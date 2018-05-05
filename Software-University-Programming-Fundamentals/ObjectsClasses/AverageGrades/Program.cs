using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int totalStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalStudents; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                double[] grades = input.Skip(1).Select(double.Parse).ToArray();

                students.Add(new Student { Name = input[0], Grades = grades });
            }

            List<Student> orderedStudents = students.Where(grade => grade.AverageGrade >= 5.00).OrderBy(student => student.Name).ThenByDescending(grade => grade.AverageGrade).ToList();

            for (int i = 0; i < orderedStudents.Count; i++)
            {
                Console.WriteLine($"{orderedStudents[i].Name} -> {orderedStudents[i].AverageGrade:F2}");
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public double[] Grades { get; set; }

        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
    }
}
