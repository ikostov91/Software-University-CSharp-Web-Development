using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.App.Dtos
{
    public class PassportDto
    {
        public string SerialNumber { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerName { get; set; }
        public string RegistrationDate { get; set; }
    }
}
