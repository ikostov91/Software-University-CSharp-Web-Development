using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());         

            int topStudents      = 0, averageStudents = 0,  
                lowGradeStudents = 0, failedStudents  = 0;
            double totalGrade = 0, averageGrade = 0 , topStudentsPercentage   = 0, averagStudentsPercentage = 0,
                   lowGradeStudentsPercentage   = 0, failedStudentsPercentage = 0;

            for (int i = 1; i <= studentsCount; i++)
            {
                double studentGrade = double.Parse(Console.ReadLine());

                totalGrade += studentGrade;

                if (studentGrade >= 5.00)
                {
                    topStudents++;
                }
                else if (studentGrade >= 4.00 && studentGrade <= 4.99)
                {
                    averageStudents++;
                }
                else if (studentGrade >= 3.00 && studentGrade <= 3.99)
                {
                    lowGradeStudents++;
                }
                else
                {
                    failedStudents++;
                }
            }

            topStudentsPercentage      = (double)topStudents / studentsCount * 100;
            averagStudentsPercentage   = (double)averageStudents / studentsCount * 100;
            lowGradeStudentsPercentage = (double)lowGradeStudents / studentsCount * 100;
            failedStudentsPercentage   = (double)failedStudents / studentsCount * 100;
            averageGrade = totalGrade / studentsCount;

            Console.WriteLine("Top students: {0:F2}%", topStudentsPercentage);
            Console.WriteLine("Between 4.00 and 4.99: {0:F2}%", averagStudentsPercentage);
            Console.WriteLine("Between 3.00 and 3.99: {0:F2}%", lowGradeStudentsPercentage);
            Console.WriteLine("Fail: {0:F2}%", failedStudentsPercentage);
            Console.WriteLine("Average: {0:F2}", averageGrade);
        }
    }
}
