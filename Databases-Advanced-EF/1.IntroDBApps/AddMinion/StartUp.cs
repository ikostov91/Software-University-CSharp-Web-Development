using System;
using System.Data.SqlClient;

namespace AddMinion
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

                string[] minionData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None);
                string[] villainData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None);

                string minionName = minionData[1];
                int minionAge = int.Parse(minionData[2]);
                string minionTown = minionData[3];
                string villainName = villainData[1];

                object doesTownExist = CheckTownExistsInDatabase(minionTown, connection);
                if (doesTownExist == null)
                {
                    InsertTown(minionTown, connection);
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                InsertMinion(minionName, minionAge, minionTown, connection);

                object doesVillainExist = CheckVillainExistsInDatabase(villainName, connection);
                if (doesVillainExist == null)
                {
                    InsertVillain(villainName, connection);
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                SetMinionToVillain(minionName, minionAge, villainName, connection);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

                connection.Close();
            }
        }

        private static void SetMinionToVillain(string minionName, int minionAge, string villainName, SqlConnection connection)
        {
            string setMinionToVillain = "INSERT INTO MinionsVillains VALUES ((SELECT Id FROM Minions WHERE [Name] = @minionName AND Age = @age), (SELECT Id FROM Villains WHERE [Name] = @villainName))";
            SqlCommand setMinionVillainCommand = new SqlCommand(setMinionToVillain, connection);
            setMinionVillainCommand.Parameters.AddWithValue("@minionName", minionName);
            setMinionVillainCommand.Parameters.AddWithValue("@age", minionAge);
            setMinionVillainCommand.Parameters.AddWithValue("@villainName", villainName);
            using (setMinionVillainCommand)
            {
                setMinionVillainCommand.ExecuteNonQuery();
            }
        }

        private static void InsertMinion(string minionName, int minionAge, string minionTown, SqlConnection connection)
        {
            string insertMinionQuery = "INSERT INTO Minions VALUES (@name, @age, (SELECT Id FROM Towns WHERE [Name] = @town))";
            SqlCommand insertMinionCommand = new SqlCommand(insertMinionQuery, connection);
            insertMinionCommand.Parameters.AddWithValue("@name", minionName);
            insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
            insertMinionCommand.Parameters.AddWithValue("@town", minionTown);
            using (insertMinionCommand)
            {
                insertMinionCommand.ExecuteNonQuery();
            }
        }

        private static object CheckVillainExistsInDatabase(string villainName, SqlConnection connection)
        {
            string checkVillain = "SELECT * FROM Villains WHERE [Name] = @name";
            SqlCommand checkVillainCommand = new SqlCommand(checkVillain, connection);
            checkVillainCommand.Parameters.AddWithValue("@name", villainName);
            object result = checkVillainCommand.ExecuteScalar();
            return result;
        }

        private static void InsertVillain(string villainName, SqlConnection connection)
        {
            string insertVillainQuery = "INSERT INTO Villains VALUES (@name, 4)";
            SqlCommand insertVillainCommand = new SqlCommand(insertVillainQuery, connection);
            insertVillainCommand.Parameters.AddWithValue("@name", villainName);
            using (insertVillainCommand)
            {
                insertVillainCommand.ExecuteNonQuery();
            }
        }

        private static object CheckTownExistsInDatabase(string town, SqlConnection connection)
        {
            string query = "SELECT * FROM Towns WHERE [Name] = @town";
            SqlCommand checkTownCommand = new SqlCommand(query, connection);
            checkTownCommand.Parameters.AddWithValue("@town", town);
            object result = checkTownCommand.ExecuteScalar();
            return result;
        }

        private static void InsertTown(string town, SqlConnection connection)
        {
            string insertTownQuery = "INSERT INTO Towns VALUES (@town, 1)";
            SqlCommand insertTownCommand = new SqlCommand(insertTownQuery, connection);
            insertTownCommand.Parameters.AddWithValue("@town", town);
            using (insertTownCommand)
            {
                insertTownCommand.ExecuteNonQuery();
            }
        }
    }
}
