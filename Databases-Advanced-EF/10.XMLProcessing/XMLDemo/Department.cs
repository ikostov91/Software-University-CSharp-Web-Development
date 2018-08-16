using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLDemo
{
    [XmlType("Department")]
    public class Department
    {
        [XmlAttribute("departmentId")]
        public int Id { get; set; }

        [XmlElement("departmentName")]
        public string Name { get; set; }

        [XmlArray]
        public List<Person> Employees { get; set; } //=
        //{
        //    new Person() { Name = "Ivo", Age = 26 },
        //    new Person() { Name = "Naska", Age = 45 },
        //    new Person() { Name = "Pesho", Age = 13 }
        //};
    }
}
