using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Department dept = new Department()
            {
                Id = 1991,
                Name = "SoftUni"
            };

            var employees = new List<Person>()
            {
                new Person() { Name = "Stamat", Age = 26 },
                new Person() { Name = "Gerasim", Age = 45 },
                new Person() { Name = "Lolio", Age = 33 }
            };

            dept.Employees = employees;

            XmlSerializer serializer = new XmlSerializer(typeof(Department));

            Serialize(dept, serializer);

            string xmlFileString = Deserialize("department.xml");

            XDocument document = XDocument.Parse(xmlFileString);

            Department deptObjectOne = (Department) serializer.Deserialize(new StreamReader("department.xml"));

            Department deptObjectTow = (Department) serializer.Deserialize(new StringReader(xmlFileString));

            var employeesNames = document.Root
                .Element("Employees")
                .Elements("Person")
                .Select(x => new
                {
                    Name = x.Element("personName").Value,
                    Age = x.Element("personAge").Value
                }).ToList();

            foreach (var person in employeesNames)
            {
                Console.WriteLine(person.Name + " " + person.Age);
            }
        }

        private static void Serialize(Department dept, XmlSerializer serializer)
        {
            using (var writer = new StreamWriter("department.xml"))
            {
                serializer.Serialize(writer, dept);
            }
        }

        private static string Deserialize(string filePath)
        {
            string xmlString;

            using (var reader = new StreamReader(filePath))
            {
                xmlString = reader.ReadToEnd();
            }

            return xmlString;
        }
    }
}
