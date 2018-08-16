using System;
using System.Data.SqlClient;

namespace MinionNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                connection.ChangeDatabase(Configuration.DatabaseName);

                string villainName = GetVillainName(villainId, connection);
                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {villainName}");
                    PrintNames(villainId, connection);
                }

                connection.Close();
            }
        }

        private static void PrintNames(int villainId, SqlConnection connection)
        {
            string minions = "SELECT m.[Name] AS [Name], " +
                             "m.Age AS [Age] " +
                             "FROM Minions AS m " +
                             "JOIN MinionsVillains AS mv " +
                             "ON mv.MinionId = m.Id " +
                             "WHERE mv.VillainId = @id";

            using (SqlCommand command = new SqlCommand(minions, connection))
            {
                command.Parameters.AddWithValue("@id", villainId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        int rows = 1;
                        while (reader.Read())
                        {
                            Console.WriteLine($"{rows}. {reader[0]} - {reader[1]}");
                        }
                    }
                }
            }
        }

        private static string GetVillainName(int villainId, SqlConnection connection)
        {
            string nameSql = "SELECT v.[Name] FROM Villains AS v WHERE Id = @id";

            using (SqlCommand command = new SqlCommand(nameSql, connection))
            {
                command.Parameters.AddWithValue("@id", villainId);
                return (string) command.ExecuteScalar();
            }
        }
    }
}
