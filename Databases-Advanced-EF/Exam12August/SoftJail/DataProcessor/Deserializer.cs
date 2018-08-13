using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;

namespace SoftJail.DataProcessor
{
    using Data;
    using System;

    public class Deserializer
    {
        private const string FailureMessage = "Invalid Data";
        private const string SuccessMessageDepartments = "Imported {0} with {1} cells";
        private const string SuccessMessagePrisoners = "Imported {0} {1} years old";
        private const string SuccessMessageOfficers = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            List<Department> validDepartments = new List<Department>();
            StringBuilder sb = new StringBuilder();

            var deserializedDepartments = JsonConvert.DeserializeObject<Department[]>(jsonString);
            
            foreach (var department in deserializedDepartments)
            {
                bool validCells = true;

                if (!IsValid(department))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var cell in department.Cells)
                {
                    cell.DepartmentId = department.Id;
                    cell.Department = department;

                    if (!IsValid(cell))
                    {
                        sb.AppendLine(FailureMessage);
                        validCells = false;
                        break;
                    }
                }

                if (!validCells)
                {
                    continue;
                }

                validDepartments.Add(department);
                sb.AppendLine(string.Format(SuccessMessageDepartments, department.Name, department.Cells.Count));
            }
            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            List<Prisoner> validPrisoners = new List<Prisoner>();
            StringBuilder sb = new StringBuilder();

            var deserializedPrisoners = JsonConvert.DeserializeObject<Prisoner[]>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            foreach (var prisoner in deserializedPrisoners)
            {
                bool validMails = true;

                if (!IsValid(prisoner))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var mail in prisoner.Mails)
                {
                    mail.PrisonerId = prisoner.Id;
                    mail.Prisoner = prisoner;

                    if (!IsValid(mail))
                    {
                        sb.AppendLine(FailureMessage);
                        validMails = false;
                        break;
                    }
                }

                if (!validMails)
                {
                    continue;
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessMessagePrisoners, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            List<Officer> validOfficers = new List<Officer>();
            StringBuilder sb = new StringBuilder();

            var document = XDocument.Parse(xmlString);
            var officerElements = document.Root.Elements();

            foreach (var officerElement in officerElements)
            {
                bool arePrisonersValid = true;

                string officerName = officerElement.Element("Name")?.Value;
                decimal? salary = decimal.TryParse(officerElement.Element("Money")?.Value, out var tempSalary) ? tempSalary : (decimal?)null;
                Position? position = Enum.TryParse<Position>(officerElement.Element("Position")?.Value, out var tempPosition) ? tempPosition : (Position?)null;
                Weapon? weapon = Enum.TryParse<Weapon>(officerElement.Element("Weapon")?.Value, out var tempWeapon) ? tempWeapon : (Weapon?)null;
                int? departmentId = int.TryParse(officerElement.Element("DepartmentId")?.Value, out var tempDeptId) ? tempDeptId : (int?)null;

                bool isDeptIdValid = context.Departments.Any(x => x.Id == departmentId);

                if (officerName == null || salary == null || position == null || weapon == null || departmentId == null || isDeptIdValid == false)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = officerName,
                    Salary = (decimal)salary,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                    DepartmentId = (int)departmentId,
                    Department = context.Departments.First(x => x.Id == departmentId)
                };

                if (!IsValid(officer))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                List<int> prisonerIds = officerElement.Element("Prisoners").Elements().Attributes("id").Select(x => int.Parse(x.Value)).ToList();
                List<OfficerPrisoner> officerPrisoners = new List<OfficerPrisoner>();

                foreach (var id in prisonerIds)
                {
                    int? prisonerId = context.Prisoners.FirstOrDefault(x => x.Id == id)?.Id;
                    if (prisonerId == null)
                    {
                        arePrisonersValid = false;
                        sb.AppendLine(FailureMessage);
                        break;
                    }

                    OfficerPrisoner officerPrisoner = new OfficerPrisoner()
                    {
                        OfficerId = officer.Id,
                        Officer = officer,
                        PrisonerId = id,
                        Prisoner = context.Prisoners.First(x => x.Id == id)
                    };
                    officerPrisoners.Add(officerPrisoner);
                }

                if (!arePrisonersValid)
                {
                    continue;
                }

                officer.OfficerPrisoners = officerPrisoners;
                validOfficers.Add(officer);
                sb.AppendLine(string.Format(SuccessMessageOfficers, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}