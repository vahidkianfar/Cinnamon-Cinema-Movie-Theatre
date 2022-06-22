using System.Collections.Specialized;
using System;  
using System.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;
namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class DatabaseConnection
{
    private static string username;
    private static string password;
    private static string host;
    private static string database;
    
    public static NpgsqlConnection GetConnection()
    {
        username = ConfigurationManager.AppSettings["DBusername"];
        password = ConfigurationManager.AppSettings["DBPassword"];
        host = ConfigurationManager.AppSettings["DBHost"];
        database = ConfigurationManager.AppSettings["DBName"];
        var connectionString = $"Server={host};User Id={username};Password={password};Database={database};";
        return new NpgsqlConnection(connectionString);
    }
    
    // public static NpgsqlConnection GetConnection()
    // {
    //     return new NpgsqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    // }

}