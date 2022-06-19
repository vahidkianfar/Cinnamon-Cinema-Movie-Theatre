using System.Numerics;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class UserManager
{
    private static NpgsqlConnection? _connection { get; set; }
    public UserManager(NpgsqlConnection? connection)=>_connection = connection;
    public List<Tuple<string,string, BigInteger,int>>? UserDetails { get; set; }
    public static void SetConnection(NpgsqlConnection? connection)=>_connection = connection;
    public static void GetUserDetails(UserManager user)
    {
        var cmd = new NpgsqlCommand("SELECT * FROM users", _connection);
        var reader = cmd.ExecuteReader();
        var users = new List<Tuple<string,string,BigInteger,int>>();
        while (reader.Read())
        {
            users.Add(new Tuple<string,string, BigInteger,int>
                 (reader.GetString(0), reader.GetString( 1), reader.GetInt64(2), reader.GetInt32(3)));
        }
        user.UserDetails = users;
    }

    public static bool Login(string username, string password)
    {
        var cmd = new NpgsqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", _connection);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        var reader = cmd.ExecuteReader();
        return reader.Read();
    }
    public static bool Register(string username, string password)
    {
        var cmd = new NpgsqlCommand("INSERT INTO users (username, password) VALUES (@username, @password)", _connection);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        return cmd.ExecuteNonQuery() > 0;
    }
}