﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Visitations = new List<Visitation>();
            this.Diagnoses = new List<Diagnose>();
            this.Prescriptions = new List<PatientMedicament>();
        }

        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
