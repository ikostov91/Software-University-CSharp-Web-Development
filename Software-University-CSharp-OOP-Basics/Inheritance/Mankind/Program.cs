using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] studentInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string firstName = studentInfo[0];
            string lastName = studentInfo[1];
            string facultyNumber = studentInfo[2];
            Student student = new Student(firstName, lastName, facultyNumber);

            string[] workerInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            firstName = workerInfo[0];
            lastName = workerInfo[1];
            decimal weekSalary = decimal.Parse(workerInfo[2]);
            int workHoursPerDay = int.Parse(workerInfo[3]);
            Worker worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);

            Console.WriteLine(student.ToString() + Environment.NewLine);
            Console.WriteLine(worker.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

