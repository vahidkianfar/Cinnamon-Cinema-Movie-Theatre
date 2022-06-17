using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre;

public class SeatManager:IDatabase
{
    public List<Tuple<string, int,int>> seatsStatus { get; private set; }
    public static async Task GetAvailableSeats(SeatManager seatManagerDetails)
    {
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        
        await using var command = new NpgsqlCommand(
            "SELECT rowblock, columnnumber, status FROM seats ORDER BY rowblock, columnnumber",
            connectionToDatabase);
        
        {
            await using var reader = await command.ExecuteReaderAsync();
            var result = new List<Tuple<string,int,int>>();
            while (await reader.ReadAsync())
                result.Add(new Tuple<string, int,int>
                    (reader.GetString(0), reader.GetInt32( 1), reader.GetInt32(2)));
            seatManagerDetails.seatsStatus = result;
        }
    }

    public static async Task UpdateSeatStatus(char selectedRow, int selectedCols,int newStatus)
    {
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        // var commandText = @"UPDATE seats
        //         SET status = @status WHERE rowblock=@rows AND columnnumber=@cols";

        await using (var command = new NpgsqlCommand($"UPDATE seats SET status = '{newStatus}' " +
                                                     $"WHERE rowblock='{selectedRow}' AND columnnumber='{selectedCols}' ", connectionToDatabase))
        {
            command.Parameters.AddWithValue(@"status", newStatus);
            command.Parameters.AddWithValue(@"rowblock", selectedRow);
            command.Parameters.AddWithValue(@"columnnumber", selectedCols);
            await command.ExecuteNonQueryAsync();
        }
    }
}