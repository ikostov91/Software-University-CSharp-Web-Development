using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChangeTownNamesCasing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                connection.ChangeDatabase(Configuration.DatabaseName);

                int countryId = GetCountryId(country, connection);
                if (countryId == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    int rows = UpdateTownsNameInCountry(countryId, connection);
                    Console.WriteLine($"{rows} town names were affected.");

                    string[] townsAffected = GetAffectedTowns(countryId, connection);
                    Console.WriteLine($"[{string.Join(", ", townsAffected)}]");
                }

                connection.Close();
            }
        }

        private static string[] GetAffectedTowns(int countryId, SqlConnection connection)
        {
            List<string> townsResultSet = new List<string>();
            string getTowns = "SELECT [Name] FROM Towns WHERE CountryCode = @countryId";
            SqlCommand getTownsCommand = new SqlCommand(getTowns, connection);
            getTownsCommand.Parameters.AddWithValue("@countryId", countryId);

            SqlDataReader reader = getTownsCommand.ExecuteReader();

            while (reader.Read())
            {
                townsResultSet.Add(reader[0].ToString());
            }

            return townsResultSet.ToArray();
        }

        private static int UpdateTownsNameInCountry(int countryId, SqlConnection connection)
        {
            string updateTowns = "UPDATE Towns SET [Name] = UPPER([Name]) WHERE CountryCode = @countryId";
            SqlCommand updateTownsCommand = new SqlCommand(updateTowns, connection);
            updateTownsCommand.Parameters.AddWithValue("@countryId", countryId);

            using (updateTownsCommand)
            {
                return updateTownsCommand.ExecuteNonQuery();
            }
        }

        private static int GetCountryId(string country, SqlConnection connection)
        {
            string checkCountryQuery = "SELECT Id FROM Countries WHERE [Name] = @countryName";
            SqlCommand command = new SqlCommand(checkCountryQuery, connection);
            command.Parameters.AddWithValue("@countryName", country);

            using (command)
            {
                object result = command.ExecuteScalar();

                if (result == null)
                {
                    return 0;
                }

                return (int)result;
            }
        }
    }
}
