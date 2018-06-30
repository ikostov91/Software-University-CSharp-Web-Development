using System;
using System.Data.SqlClient;

namespace IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                connection.ChangeDatabase(Configuration.DatabaseName);

                bool minionExists = CheckMinionExists(minionId, connection);
                if (minionExists)
                {
                    IncreaseAge(minionId, connection);
                    PrintNameAge(minionId, connection);
                }
                else
                {
                    Console.WriteLine($"No minion with ID {minionId} in the database.");        
                }

                connection.Close();
            }
        }

        private static void PrintNameAge(int minionId, SqlConnection connection)
        {
            string nameAge = "SELECT m.[Name], m.Age FROM Minions AS m WHERE Id = @id";
            SqlCommand command = new SqlCommand(nameAge, connection);
            command.Parameters.AddWithValue("@id", minionId);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]} years old");
                }
            }
        }

        private static void IncreaseAge(int minionId, SqlConnection connection)
        {
            string increaseAge = "EXEC usp_GetOlder @id";
            SqlCommand command = new SqlCommand(increaseAge, connection);
            command.Parameters.AddWithValue("@id", minionId);

            using (command)
            {
                command.ExecuteNonQuery();
            }
        }

        private static bool CheckMinionExists(int minionId, SqlConnection connection)
        {
            string minionExists = "SELECT * FROM Minions WHERE Id = @id";
            SqlCommand command = new SqlCommand(minionExists, connection);
            command.Parameters.AddWithValue("@id", minionId);

            using (command)
            {
                var result = command.ExecuteScalar();

                if (result == null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
