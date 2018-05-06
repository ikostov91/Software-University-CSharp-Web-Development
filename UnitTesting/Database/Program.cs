using System;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database(1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7);

            try
            {
                db.Add(10);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
