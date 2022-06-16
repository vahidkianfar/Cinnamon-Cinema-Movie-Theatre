using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre;

public class Seats:IDatabase
{
    
    public List<Tuple<string, int>> seatsStatus { get; private set; }
    public static async Task GetAvailableSeats(Seats seatDetails)
    {
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        
        await using var command = new NpgsqlCommand(
            "SELECT rowblock, columnnumber FROM seats WHERE status=true ORDER BY rowblock, columnnumber",
            connectionToDatabase);
        
        {
            await using var reader = await command.ExecuteReaderAsync();
            var result = new List<Tuple<string,int>>();
            while (await reader.ReadAsync())
                result.Add(new Tuple<string, int>
                    (reader.GetString(0), reader.GetInt32( 1)));
            seatDetails.seatsStatus = result;
        }
    }
    
}