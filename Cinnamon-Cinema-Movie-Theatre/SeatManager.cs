using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre;

public class SeatManager:IDatabase
{
    public List<Tuple<string, int>> seatsStatus { get; private set; }
    public static async Task GetAvailableSeats(SeatManager seatManagerDetails)
    {
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        
        await using var command = new NpgsqlCommand(
            "SELECT rowblock, columnnumber FROM seats WHERE status=0 ORDER BY rowblock, columnnumber",
            connectionToDatabase);
        
        {
            await using var reader = await command.ExecuteReaderAsync();
            var result = new List<Tuple<string,int>>();
            while (await reader.ReadAsync())
                result.Add(new Tuple<string, int>
                    (reader.GetString(0), reader.GetInt32( 1)));
            seatManagerDetails.seatsStatus = result;
        }
    }

    public static async Task UpdateSeatStatus(char rows, int cols,int status)
    {
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        // var commandText = @"UPDATE seats
        //         SET status = @status WHERE rowblock=@rows AND columnnumber=@cols";

        await using (var command = new NpgsqlCommand("UPDATE seats SET status = @status " +
                                                     "WHERE rowblock='A' AND columnnumber=1", connectionToDatabase))
        {
            command.Parameters.AddWithValue(@"status", status);
            await command.ExecuteNonQueryAsync();
        }
    }
}