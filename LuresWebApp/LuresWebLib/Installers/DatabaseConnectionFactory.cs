namespace LuresWebLib.Installers
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class DatabaseConnectionFactory: IConnectionStringFactory
    {
        public string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings["LuresConnectionString"].ConnectionString;

        }
    }
}