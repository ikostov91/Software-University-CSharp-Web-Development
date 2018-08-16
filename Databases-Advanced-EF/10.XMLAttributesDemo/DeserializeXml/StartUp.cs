using System;
using System.IO;
using System.Xml.Serialization;
using DeserializeXml.Dtos;

namespace DeserializeXml
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string xmlString = File.ReadAllText("users.xml");
            var reader = new StringReader(xmlString);

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            var users = (UserDto[])serializer.Deserialize(reader);

            foreach (var user in users)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
        }
    }
}
