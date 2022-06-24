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
                var selectInstructionOption = ConsoleHelper.MultipleChoiceForAdmin(true,
                    "1. Add Movie",
                    "2. Delete Movie",
                    "3. Update Movie",
                    "4. Get All Available Movies",
                    "5. Logout",
                    "6. Exit"
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(checkAddMovie ? "Movie added successfully!" : "Movie already exists!");
                        Console.ResetColor();
                        break;
                    }
                    
                    case 1:
                        MovieManager.SetConnection(connectionToDatabase);
                        Console.Write("Enter Title: ");
                        var deleteTitle = Console.ReadLine()!;
                        var checkDeleteMovie = MovieManager.DeleteMovie(deleteTitle);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(checkDeleteMovie ? "Movie Deleted successfully!" : "Movie does not exist!");
                        Console.ResetColor();
                        break;

                    case 3:
                    {
                        MovieManager.SetConnection(connectionToDatabase);
                        var movieList = MovieManager.GetMovieList();
                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (var item in movieList)
                        {
                            Console.ResetColor();
                            Console.Write("Title: ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(item.Item2);
                            Console.ResetColor();
                            Console.Write(" - Genre: ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(item.Item1);
                            Console.ResetColor();
                            Console.Write(" - Director: ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(item.Item3);
                            Console.WriteLine();
                            
                        }
                        Console.ResetColor();

                        break;
                    }
                    
                    case 4:
                        UserMenu.Start();
                        break;
                    case 5:
                        CinemaBanner.PrintBanner();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}