using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLDemo
{
    [XmlType("Person")]
    public class Person
    {
        [XmlAttribute("personId")]
        public int Id { get; set; }

        [XmlElement("personName")]
        public string Name { get; set; }

        [XmlElement("personAge")]
        public int Age { get; set; }
    }
}
