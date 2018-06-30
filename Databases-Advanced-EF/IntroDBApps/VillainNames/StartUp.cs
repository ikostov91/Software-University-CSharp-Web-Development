using System;
using System.Data.SqlClient;

namespace VillainNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                connection.ChangeDatabase(Configuration.DatabaseName);

                string getVillainsNames =
                    "SELECT v.[Name]," +
                           "COUNT(mv.MinionId) AS [MinionCount]" +
                      "FROM Villains AS v " +
                      "JOIN MinionsVillains AS mv " +
                        "ON mv.VillainId = v.Id " +
                  "GROUP BY v.Id, v.[Name] " +
                    "HAVING COUNT(mv.MinionId) >= 3 " +
                  "ORDER BY [MinionCount] DESC";

                SqlCommand command = new SqlCommand(getVillainsNames, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Format("{0} - {1}", reader[0], reader[1]));
                    }
                }

                connection.Close();
            }
        }
    }
}
