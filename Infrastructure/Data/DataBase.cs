using System.Data;
using Microsoft.VisualBasic;
using Npgsql;

namespace Infrastructure.Data;

public static class DataBase
{
    private static string connectionString = "Host=localhost;Port=5432;DataBase=Magazin;Username=postgres;Password=1234";
    public static NpgsqlConnection Connection() => new NpgsqlConnection(connectionString);
}
