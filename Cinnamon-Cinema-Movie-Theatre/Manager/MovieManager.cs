using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class MovieManager:IDatabase
{
    public static List<Tuple<string,string,string>>? MovieDetails { get; private set; }
    // public string Genre { get; set; }
    // public string Director { get; set; }
    public static NpgsqlConnection? _connection { get; set; }
    public MovieManager(NpgsqlConnection? connection)=>_connection = connection;
    public static void GetMovieDetails()
    {
          var command = new NpgsqlCommand("SELECT genre, title, director FROM movies", _connection);
          {
              using var reader = command.ExecuteReader();
              var title = new List<Tuple<string, string, string>>();
              while (reader.Read())
                  title.Add(new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1),
                      reader.GetString(2)));
              MovieDetails = title;
          }
    }
}