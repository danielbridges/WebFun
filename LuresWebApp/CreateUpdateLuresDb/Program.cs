namespace CreateUpdateLuresDb
{
    using System;
    using System.Data.SQLite;
    using System.IO;
    using System.Reflection;

    using DbUp;

    public class Program
    {
        private static int Main()
        {
#if WIN64
            const string appDataPath = "../../../../LuresWebApp/App_Data";
#else
            const string appDataPath = "../../../LuresWebApp/App_Data";
#endif
            Directory.CreateDirectory(appDataPath);
            SQLiteConnection.CreateFile($"{appDataPath}/lures.db");
            using (var conn = new SQLiteConnection($"Data Source={appDataPath}/lures.db"))
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
