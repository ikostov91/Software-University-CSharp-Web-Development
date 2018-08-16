using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {

            var animals = context.Animals.Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.Passport.SerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate
                })
                .OrderBy(x => x.Age)
                .ThenBy(x => x.SerialNumber)
                .ToArray();

            var jsonAnimals = JsonConvert.SerializeObject(animals, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd-MM-yyyy"
            });

            return jsonAnimals;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .Select(x => new
                {
                    Passport = x.Animal.Passport.SerialNumber,
                    OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                    DateTime = x.DateTime,
                    AnimalAids = x.ProcedureAnimalAids.Select(y => new
                    {
                        Name = y.AnimalAid.Name,
                        Price = y.AnimalAid.Price
                    }),
                    TotalPrice = x.ProcedureAnimalAids.Select(p => p.AnimalAid.Price).Sum(),
                })
                .OrderBy(x => x.DateTime)
                .ThenBy(x => x.Passport)
                .ToArray();

            var xmlDOc = new XDocument(new XElement("Procedures"));

            foreach (var procedure in procedures)
            {
                xmlDOc.Root.Add
                (
                    new XElement("Procedure",
                        new XElement("Passport", procedure.Passport),
                        new XElement("OwnerNumber", procedure.OwnerNumber),
                        new XElement("DateTime",
                            procedure.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)),
                        new XElement("AnimalAids", procedure.AnimalAids.Select(aid =>
                                new XElement("AnimalAid",
                                    new XElement("Name", aid.Name),
                                    new XElement("Price", aid.Price)))),
                            new XElement("TotalPrice", procedure.TotalPrice))
                );
            }

            string result = xmlDOc.ToString();
            return result;
        }
    }
}
