using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.App.Dtos
{
    [XmlType("Vets")]
    public class VetDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Profession")]
        public string Profession { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
