namespace LuresWebLib.Installers
{
    public interface IConnectionStringFactory
    {
        string GetConnectionString(string connectionStringName);
    }
}