using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Type { get; set; }

        [Range(typeof(int), "1", "666")]
        public int Age { get; set; }

        public string PassportSerialNumber { get; set; }
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
