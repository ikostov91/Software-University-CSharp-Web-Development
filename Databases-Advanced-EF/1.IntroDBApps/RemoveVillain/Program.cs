using System;
using System.Data.SqlClient;

namespace RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            using (connection)
            {
                connection.Open();
                connection.ChangeDatabase(Configuration.DatabaseName);

                int villainId = int.Parse(Console.ReadLine());

                bool isVillainIdDB = CheckVillainIsInDB(villainId, connection);
                if (isVillainIdDB)
                {
                    SqlTransaction transaction = connection.BeginTransaction("DeleteVillainTransaction");
                    
                }
                else
                {
                    Console.WriteLine("No such villain was found.");        
                }
                



                connection.Close();
            }
        }

        private static bool CheckVillainIsInDB(int villainId, SqlConnection connection)
        {
            string checkVillainQuery = $"SELECT * FROM Villains WHERE Id = {villainId}";
            SqlCommand checkVillainCommand = new SqlCommand(checkVillainQuery, connection);

            using (checkVillainCommand)
            {
                object result = checkVillainCommand.ExecuteScalar();

                if (result == null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
