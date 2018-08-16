using System;
using System.Data.SqlClient;
using System.Linq;

namespace IncreaseMinionAge
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] minionsIds = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None).Select(int.Parse).ToArray();

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                connection.ChangeDatabase(Configuration.DatabaseName);

                foreach (var minionId in minionsIds)
                {
                    bool minionExists = CheckIfMinionExists(minionId, connection);
                    if (minionExists)
                    {
                        IncreaseAge(minionId, connection);
                        MakeNameTitleCase(minionId, connection);
                    }
                }

                PrintAllMinions(connection);

                connection.Close();
            }
        }

        private static void PrintAllMinions(SqlConnection connection)
        {
            string minionNameAge = "SELECT m.[Name], m.Age FROM Minions AS m";
            SqlCommand command = new SqlCommand(minionNameAge, connection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }       
            }
        }

        private static void MakeNameTitleCase(int minionId, SqlConnection connection)
        {
            string makeNameTitleCase = "UPDATE Minions " +
            "SET[Name] = CONCAT(UPPER(SUBSTRING([Name], 1, 1)),'',LOWER(SUBSTRING([Name], 2, LEN([Name]) - 1))) " +
            "WHERE Id = @id";
            SqlCommand command = new SqlCommand(makeNameTitleCase, connection);
            command.Parameters.AddWithValue("@id", minionId);
            command.ExecuteNonQuery();
        }

        private static void IncreaseAge(int minionId, SqlConnection connection)
        {
            string updateAge = "UPDATE Minions SET Age += 1 WHERE Id = @id";
            SqlCommand command = new SqlCommand(updateAge, connection);
            command.Parameters.AddWithValue("@id", minionId);
            command.ExecuteNonQuery();
        }

        private static bool CheckIfMinionExists(int minionId, SqlConnection connection)
        {
            string minionQuery = "SELECT * FROM Minions WHERE Id = @id";
            SqlCommand command = new SqlCommand(minionQuery, connection);
            command.Parameters.AddWithValue("@id", minionId);

            using (command)
            {
                if (command.ExecuteScalar() == null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
