using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Presciptions = new List<PatientMedicament>();
        }

        public int MedicamentId { get; set; }

        public string Name { get; set; }

        public ICollection<PatientMedicament> Presciptions { get; set; }
    }
}
