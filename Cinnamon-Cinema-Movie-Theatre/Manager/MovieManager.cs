using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class Movies:IDatabase
{
    public List<string> Title { get; private set; }
    public string Genre { get; set; }
    public string Director { get; set; }

    public async Task<NpgsqlConnection> GetConnection()
    {
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        return connectionToDatabase;
    }
    public static async Task GetMovieTitle(Movies movie)
    {
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        
        await using var command = new NpgsqlCommand(
            "SELECT title FROM movies",
            connectionToDatabase
        );
        await using (var reader = await command.ExecuteReaderAsync())
        {
            var title = new List<string>();
            while (await reader.ReadAsync())
                title.Add(reader.GetString(0));
            movie.Title = title;
        }
    }
}