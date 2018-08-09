using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using PetClinic.App.Dtos;
using PetClinic.Models;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            List<AnimalAid> animalAids = new List<AnimalAid>();
            StringBuilder sb = new StringBuilder();

            var animalAidsObj = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            foreach (var animalAid in animalAidsObj)
            {
                if (animalAids.Any(x => x.Name.ToLower() == animalAid.Name.ToLower()) || !IsValid(animalAid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                animalAids.Add(animalAid);
                sb.AppendLine(string.Format(SuccessMessage, animalAid.Name));
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            List<Animal> animals = new List<Animal>();
            StringBuilder sb = new StringBuilder();

            var animalsDtos = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            foreach (var animalDto in animalsDtos)
            {
                Animal animal = Mapper.Map<Animal>(animalDto);

                if (animals.Any(x => x.Passport.SerialNumber == animal.Passport.SerialNumber) || !IsValid(animal) || !IsValid(animal.Passport))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                animals.Add(animal);
                sb.AppendLine(string.Format(SuccessMessage, $"{animal.Name} Passport №: {animal.Passport.SerialNumber}"));
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            List<Vet> vets = new List<Vet>();
            StringBuilder sb = new StringBuilder();

            var document = XDocument.Parse(xmlString);
            var vetsElements = document.Root.Elements();

            foreach (var vetElement in vetsElements)
            {
                string name = vetElement.Element("Name")?.Value;
                string profession = vetElement.Element("Profession")?.Value;
                string ageString = vetElement.Element("Age")?.Value;
                string phoneNumber = vetElement.Element("PhoneNumber")?.Value;

                int age = 0;

                if (ageString != null)
                {
                    age = int.Parse(ageString);
                }

                Vet vet = new Vet()
                {
                    Name = name,
                    Profession = profession,
                    Age = age,
                    PhoneNumber = phoneNumber
                };

                if (vets.Any(x => x.PhoneNumber == vet.PhoneNumber) || !IsValid(vet))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                vets.Add(vet);
                sb.AppendLine(string.Format(SuccessMessage, vet.Name));
            }

            //var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            //var vetsDtos = (VetDto[])serializer.Deserialize(new StringReader(xmlString));

            //foreach (var vetDto in vetsDtos)
            //{
            //    Vet vet = Mapper.Map<Vet>(vetDto);

            //    if (vets.Any(x => x.PhoneNumber == vet.PhoneNumber) || !IsValid(vet))
            //    {
            //        sb.AppendLine(ErrorMessage);
            //        continue;
            //    }

            //    vets.Add(vet);
            //    sb.AppendLine(string.Format(SuccessMessage, vet.Name));
            //}

            context.Vets.AddRange(vets);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            List<Procedure> validProcedures = new List<Procedure>();
            List<AnimalAid> validAnimalAids = new List<AnimalAid>();
            StringBuilder sb = new StringBuilder();

            var document = XDocument.Parse(xmlString);
            var elements = document.Root.Elements();

            foreach (var element in elements)
            {
                string vetName = element.Element("Vet")?.Value;
                string passportId = element.Element("Animal")?.Value;
                string dateTimeString = element.Element("DateTime")?.Value;
                var animalAidsElements = element.Element("AnimalAids")?.Elements();

                int? vetId = context.Vets.SingleOrDefault(x => x.Name == vetName)?.Id;
                int? animalId = context.Animals.SingleOrDefault(x => x.Passport.SerialNumber == passportId)?.Id;
                var dateIsValid =
                    DateTime.TryParseExact(dateTimeString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                if (vetId == null || animalId == null || dateIsValid == false || animalAidsElements == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Procedure procedure = new Procedure()
                {
                    VetId = (int)vetId,
                    AnimalId = (int)animalId,
                    DateTime = dateTime
                };

                List<AnimalAid> animalAids = new List<AnimalAid>();
                bool allAidsExist = true;

                foreach (var aaElement in animalAidsElements)
                {
                    string name = aaElement.Element("Name").Value;
                    string priceString = aaElement.Element("Price")?.Value;

                    decimal price = 0.0m;
                    if (priceString != null)
                    {
                        price = decimal.Parse(priceString);
                    }

                    int? animalAidId = context.AnimalAids.SingleOrDefault(x => x.Name == name).Id;
                    if (animalAidId == null)
                    {
                        break;
                    }

                    AnimalAid aid = new AnimalAid()
                    {
                        Name = name,
                        Price = price
                    };


                }
            }

            return "";
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
