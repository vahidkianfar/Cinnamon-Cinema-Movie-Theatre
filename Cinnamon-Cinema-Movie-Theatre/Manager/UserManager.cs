using System.Numerics;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class UserManager
{
    private static NpgsqlConnection? _connection { get; set; }
    public UserManager(NpgsqlConnection? connection)=>_connection = connection;
    public List<Tuple<string,string, BigInteger,int>> UserDetails { get; private set; }
    public static void GetUserDetails(UserManager user)
    {
        var cmd = new NpgsqlCommand("SELECT * FROM users", _connection);
        var reader = cmd.ExecuteReader();
        var users = new List<Tuple<string,string,BigInteger,int>>();
        while (reader.Read())
        {
             //Console.WriteLine((reader.GetString(0) + reader.GetString( 1) + reader.GetInt64(2) + reader.GetInt32(3)));
             users.Add(new Tuple<string,string, BigInteger,int>
                 (reader.GetString(0), reader.GetString( 1), reader.GetInt64(2), reader.GetInt32(3)));
        }
        user.UserDetails = users;
    }
}

