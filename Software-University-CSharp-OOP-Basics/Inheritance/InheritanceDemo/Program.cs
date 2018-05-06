using System;

class Program
{
    static void Main(string[] args)
    {
        var teacher = new Teacher("Sofia");
        var employee = new Employee("Varna");
        var student = new Student("Plovdiv");
        var busDriver = new BusDriver("Bailovo");
        PrintPersonAddress(teacher);
        PrintPersonAddress(employee);
        PrintPersonAddress(student);
        PrintPersonAddress(busDriver);
    }

    static void PrintPersonAddress(Person person)
    {
        //if (person is Teacher)
        //{
        //    Teacher teacher = (Teacher)person;
        //    Console.WriteLine(teacher.address);
        //}
        //else if (person is Employee)
        //{
        //    Employee employee = (Employee)person;
        //    Console.WriteLine(employee.address);
        //}
        //else if (person is Student)
        //{
            //Student student = (Student)person;
            Console.WriteLine(person.address);
        //}
    }

    static void PrintPersonName(Person person)
    {
        Console.WriteLine(person.name);
    }
}

