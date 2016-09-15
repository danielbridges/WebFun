namespace CreateUpdateLuresDb
{
    using System;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using DbUp;

    class Program
    {
        static int Main(string[] args)
        {
            Directory.CreateDirectory("../../../data");
            SQLiteConnection.CreateFile("../../../data/lures.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=../../../data/lures.db"))
            {
                conn.Open();
                try
                {

                    var connectionString = conn.ConnectionString;

                    var upgrader =
                        DeployChanges.To
                            .SQLiteDatabase(connectionString)
                            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                            .LogToConsole()
                            .Build();

                    var result = upgrader.PerformUpgrade();

                    if (!result.Successful)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result.Error);
                        Console.ResetColor();
#if DEBUG
                        Console.ReadLine();
#endif
                        return -1;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Success!");
                    Console.ResetColor();
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
