using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class MovieManager:IDatabase
{
    public static List<Tuple<string,string,string>>? MovieDetails { get; private set; }
    private static NpgsqlConnection? _connection { get; set; }
    public MovieManager(NpgsqlConnection? connection)=>_connection = connection;
    public static void SetConnection(NpgsqlConnection? connection)=>_connection = connection;
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
    // public async Task<List<Movies>> GetMovieDetailsAsync()
    // {
    //     var command = new NpgsqlCommand("SELECT genre, title, director FROM movies", _connection);
    //     {
    //         using var reader = command.ExecuteReader();
    //         var title = new List<Tuple<string, string, string>>();
    //         while (await reader.ReadAsync())
    //             title.Add(new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1),
    //                 reader.GetString(2)));
    //         return title;
    //     }
    // }
    
    public static void SearchMovies(string searchTitle)
    {
        var command = new NpgsqlCommand("SELECT place, movie_title, rate, year, star_cast FROM imdb_top_250_movies WHERE movie_title=@movie_title", _connection);
        command.Parameters.AddWithValue("@movie_title", searchTitle);
        using var reader = command.ExecuteReader();
        if (!reader.Read())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("IMDb Rank: " + reader.GetInt32(0));
            Console.Write(" - Title: " + reader.GetString(1));
            Console.Write(" - Rate: " + Math.Round(reader.GetDouble(2), 1));
            Console.Write(" - Year: " + reader.GetInt32(3));
            Console.WriteLine();
            Console.Write("Director & Casts: " + reader.GetString(4));
            //Console.WriteLine();
            Console.ResetColor();
        }
    }
    
    public static bool AddMovie(string title, string genre, string director)
    {
        using var command = new NpgsqlCommand("INSERT INTO movies (genre, title, director) VALUES (@genre, @title, @director)", _connection);
        {
            command.Parameters.AddWithValue("@genre", genre);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@director", director);
            return command.ExecuteNonQuery() > 0;
        }
    }

    public static bool DeleteMovie(string title)
    {
        using var command = new NpgsqlCommand("DELETE FROM movies WHERE title=@title", _connection);
        {
            command.Parameters.AddWithValue("@title", title);
            return command.ExecuteNonQuery() > 0;
        }
        
    }
    public static bool UpdateMovie(string inputTitle, string inputGenre, string inputDirector)
    {
        using var command = new NpgsqlCommand(
            $"UPDATE movies SET genre = '{inputGenre}', director = '{inputDirector}' " +
            $"WHERE title='{inputTitle}' ",  _connection);
        {
            command.Parameters.AddWithValue(@"title", inputTitle);
            command.Parameters.AddWithValue(@"genre", inputGenre);
            command.Parameters.AddWithValue(@"director", inputDirector);
            return command.ExecuteNonQuery()>0;
        }
        
    }
    public static List<Tuple<string,string,string>> GetMovieList()
    {
        var command = new NpgsqlCommand("SELECT genre, title, director FROM movies", _connection);
        
        using var reader = command.ExecuteReader();
            
        var movieList = new List<Tuple<string, string, string>>();
        while (reader.Read())
            movieList.Add(new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1),
                reader.GetString(2)));
        return movieList;
    }
    
}