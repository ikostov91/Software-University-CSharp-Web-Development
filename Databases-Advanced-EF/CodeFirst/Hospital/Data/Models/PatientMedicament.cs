using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }

        public int MedicamentId { get; set; }
        
        public Patient Patient { get; set; }

        public Medicament Medicament { get; set; }
    }
}
