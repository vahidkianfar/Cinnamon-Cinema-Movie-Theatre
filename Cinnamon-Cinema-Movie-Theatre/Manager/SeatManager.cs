using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class SeatManager:IDatabase
{
    
    public static List<Tuple<string, int,int>>? SeatsStatus { get; set; }
    private static NpgsqlConnection? _connection { get; set; }
    public SeatManager(NpgsqlConnection? connection)=>_connection = connection;
    public static void SetConnection(NpgsqlConnection? connection)=>_connection = connection;

    // private static async Task<NpgsqlConnection> GetConnection()
    // {
    //     await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
    //     await connectionToDatabase.OpenAsync();
    //     return connectionToDatabase;
    // }
    
    
    // private static async Task _connection()
    // {
    //     await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
    //     await connectionToDatabase.OpenAsync();
    // }
    public static List<Tuple<string, int,int>> GetAvailableSeatsOfScreen1()
    {
         using var command = new NpgsqlCommand(
            "SELECT rowblock, columnnumber, status FROM screen_1 ORDER BY rowblock, columnnumber",
             _connection);
         {
            using var reader =  command.ExecuteReader();
            var result = new List<Tuple<string,int,int>>();
            while ( reader.Read())
                result.Add(new Tuple<string, int,int>
                    (reader.GetString(0), reader.GetInt32( 1), reader.GetInt32(2)));
            SeatsStatus = result;
            return result;
         }
         
    }

    public static List<Tuple<string, int, int>> GetAvailableSeatsOfScreen2()
    {
        using var command = new NpgsqlCommand(
            "SELECT rowblock, columnnumber, status FROM screen_2 ORDER BY rowblock, columnnumber",
            _connection);
        {
            using var reader = command.ExecuteReader();
            var result = new List<Tuple<string, int, int>>();
            while (reader.Read())
                result.Add(new Tuple<string, int, int>
                    (reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2)));
            SeatsStatus = result;
            return result;
        }
    }

    public static void UpdateSeatStatusForScreen1(char selectedRow, int selectedCols,int newStatus)
    {
        using var command = new NpgsqlCommand(
             $"UPDATE screen_1 SET status = '{newStatus}' " +
             $"WHERE rowblock='{selectedRow}' AND columnnumber='{selectedCols}' ",  _connection);
        {
            command.Parameters.AddWithValue(@"status", newStatus);
            command.Parameters.AddWithValue(@"rowblock", selectedRow);
            command.Parameters.AddWithValue(@"columnnumber", selectedCols);
            command.ExecuteNonQuery();
        }
    }
    public static void UpdateSeatStatusForScreen2(char selectedRow, int selectedCols,int newStatus)
    {
        using var command = new NpgsqlCommand(
            $"UPDATE screen_2 SET status = '{newStatus}' " +
            $"WHERE rowblock='{selectedRow}' AND columnnumber='{selectedCols}' ",  _connection);
        {
            command.Parameters.AddWithValue(@"status", newStatus);
            command.Parameters.AddWithValue(@"rowblock", selectedRow);
            command.Parameters.AddWithValue(@"columnnumber", selectedCols);
            command.ExecuteNonQuery();
        }
    }
}