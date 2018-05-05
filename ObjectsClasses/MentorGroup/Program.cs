using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Student> studentsDict = new SortedDictionary<string, Student>();

            string input = Console.ReadLine();

            while (input != "end of dates")
            {
                string[] userAndDates = input.Split(' ', ',').ToArray();
                string name = userAndDates[0];

                Student newStudent = new Student();

                newStudent.Name = name;
                newStudent.DatesAttended = new List<DateTime>();
                newStudent.Comments = new List<string>();

                if (userAndDates.Length > 1)
                {
                    for (int i = 1; i < userAndDates.Length; i++)
                    {
                        DateTime currentDate = DateTime.ParseExact(userAndDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        newStudent.DatesAttended.Add(currentDate);
                    }
                }

                if (!studentsDict.ContainsKey(newStudent.Name))
                {
                    studentsDict.Add(name, newStudent);
                }
                else
                {
                    foreach (var date in newStudent.DatesAttended)
                    {
                        studentsDict[name].DatesAttended.Add(date);
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of comments")
            {
                string[] userComments = input.Split('-').ToArray();
                string name = userComments[0];
                string comment = userComments[1];

                if (!studentsDict.ContainsKey(name))
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    studentsDict[name].Comments.Add(comment);
                }

                input = Console.ReadLine();
            }

            foreach (var student in studentsDict)
            {
                Console.WriteLine(student.Key);
                Console.WriteLine("Comments:");
                foreach (var comment in student.Value.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.Value.DatesAttended.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> DatesAttended { get; set; }
    }
}
