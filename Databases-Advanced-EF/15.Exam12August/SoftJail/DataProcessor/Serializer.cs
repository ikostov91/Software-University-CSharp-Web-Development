using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                        .Select(y => new
                        {
                            OfficerName = y.Officer.FullName,
                            Department = y.Officer.Department.Name
                        })
                        .OrderBy(n => n.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Select(s => s.Officer.Salary).Sum() 
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var jsonPrisoners = JsonConvert.SerializeObject(prisoners, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return jsonPrisoners;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            Func<string, string> stringReverser = x => x.ToCharArray().Reverse().ToString();

            string[] prisonerNamesArray = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var prisoners = context.Prisoners
                .Where(x => prisonerNamesArray.Contains(x.FullName))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate,
                    EncryptedMessages = x.Mails.Select(y => y.Description).ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            foreach (var prisoner in prisoners)
            {
                for (int message = 0; message < prisoner.EncryptedMessages.Length; message++)
                {
                    char[] charArray = prisoner.EncryptedMessages[message].ToCharArray();
                    Array.Reverse(charArray);
                    prisoner.EncryptedMessages[message] = new string(charArray);
                }
            }

            var xmlDOc = new XDocument(new XElement("Prisoners"));

            foreach (var prisoner in prisoners)
            {
                xmlDOc.Root.Add
                (
                    new XElement("Prisoner",
                        new XElement("Id", prisoner.Id),
                        new XElement("Name", prisoner.Name),
                        new XElement("IncarcerationDate",
                            prisoner.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                        new XElement("EncryptedMessages", prisoner.EncryptedMessages.Select(em =>
                            new XElement("Message",
                                new XElement("Description", em)
                )))));
            }

            string result = xmlDOc.ToString();
            return result;
        }
    }
}