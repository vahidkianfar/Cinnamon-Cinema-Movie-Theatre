using Cinnamon_Cinema_Movie_Theatre.Manager;
using Npgsql;
using Spectre.Console;
namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class AdminMenu
{
    public static void Start()
    {
        try
        {
            while (true)
            {
                using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
                connectionToDatabase.Open();
                var selectInstructionOption = ConsoleHelperForAdmin.MultipleChoiceForAdmin(true,
                    "1. Add Movie",
                    "2. Delete Movie",
                    "3. Update Movie",
                    "4. Add Screen",
                    "5. Delete Screen",
                    "6. Update Screen"
                );

                switch (selectInstructionOption)
                {
                    case 0:
                    {
                        Console.Write("Enter Title: ");
                        var movieTitle = Console.ReadLine()!;
                        Console.Write("Enter Genre: ");
                        var movieGenre = Console.ReadLine()!;
                        Console.Write("Enter Director: ");
                        var movieDirector = Console.ReadLine()!;
                        MovieManager.SetConnection(connectionToDatabase);
                        var checkAddMovie = MovieManager.AddMovie(movieTitle, movieGenre, movieDirector);
                        Console.WriteLine(checkAddMovie ? "Movie added successfully!" : "Movie already exists!");
                        break;
                    }
                }
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}