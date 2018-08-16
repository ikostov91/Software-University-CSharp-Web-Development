using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.App.Dtos
{
    public class AnimalDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public PassportDto Passport { get; set; }
    }
}
