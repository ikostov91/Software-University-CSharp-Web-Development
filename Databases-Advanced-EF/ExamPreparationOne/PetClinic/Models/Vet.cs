using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class Vet
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Profession { get; set; }

        [Range(typeof(int), "22", "65")]
        public int Age { get; set; }

        [RegularExpression(@"^(\+359|0)[0-9]{9}$")]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
