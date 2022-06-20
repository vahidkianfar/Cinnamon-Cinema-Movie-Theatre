using Cinnamon_Cinema_Movie_Theatre.Manager;
using Cinnamon_Cinema_Movie_Theatre.Models;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class SubMenu
{
    public static void ShowMoviesMenu(User loggedUser)
    {
        var connectionToDatabase = IDatabase.Connection.GetConnection();
        connectionToDatabase.Open();
        MovieManager.SetConnection(connectionToDatabase);
        MovieManager.GetMovieDetails();

        var selectInstructionOption = ConsoleHelper.MultipleChoice(true,
            $"1. Screen 1: {MovieManager.MovieDetails![0].Item2}",
            $"2. Screen 2: {MovieManager.MovieDetails![1].Item2}","3. Search Movie by Title", "4. Back", "5. Exit");
        connectionToDatabase.Close();

        switch (selectInstructionOption)
        {
            case 0:
                StartBookingScreen1(loggedUser);
                break;
            case 1:
                StartBookingScreen2(loggedUser);
                break;
            case 2:
                Console.Write("Enter the title of the movie: ");
                var searchTitle = Console.ReadLine()!;
                connectionToDatabase.Open();
                MovieManager.SetConnection(connectionToDatabase);
                MovieManager.SearchMovies(searchTitle);
                connectionToDatabase.Close();
                MainMenu.Start(loggedUser);
                break;
            case 3:
                MainMenu.Start(loggedUser);
                break;
            case 4:
                CinemaBanner.PrintBanner();
                Environment.Exit(0);
                break;
        }
    }

    
    private static void StartBookingScreen1(User loggedUser)
    {
        try
        {
            while (true)
            {
                var selectInstructionOption = ConsoleHelper.MultipleChoice(true,
                    $"1. Book Gold Seat (choose your seat)", "2. Book Silver Seat (first available seats)", "3. Back",
                    "4. Back to Main Menu", "5. Exit");
                switch (selectInstructionOption)
                {
                    case 0:
                        Console.Write("\nEnter Seat Row  (e.g. 'A'): ");
                        var inputRow = Convert.ToChar(Console.ReadLine()!);
                        Console.Write("Enter Seat Column (e.g. 1): ");
                        var inputColumn = Convert.ToInt32(Console.ReadLine()!);
                        BookingManager.ReserveGoldSeatForScreen1(char.ToUpper(inputRow), inputColumn);
                        
                        continue;

                    case 1:
                        Console.Write("Enter number of tickets (between 1 to 3) :");
                        var inputTickets = Convert.ToInt32(Console.ReadLine()!);
                        BookingManager.ReserveSilverSeatForScreen1(inputTickets);
                        continue;
                    case 2:
                        ShowMoviesMenu(loggedUser);
                        break;
                    case 3:
                        MainMenu.Start(loggedUser);
                        break;
                    case 4:
                        CinemaBanner.PrintBanner();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"System Message: {e.Message}");
            Console.ResetColor();
            StartBookingScreen1(loggedUser);
        }

    }
    private static void StartBookingScreen2(User loggedUser)
    {
        try
        {
            while (true)
            {
                var selectInstructionOption = ConsoleHelper.MultipleChoice(true,
                    $"1. Book Gold Seat (choose your seat)", "2. Book Silver Seat (first available seats)", "3. Back",
                    "4. Back to Main Menu", "5. Exit");
                switch (selectInstructionOption)
                {
                    case 0:
                        Console.Write("\nEnter Seat Row  (e.g. 'A'): ");
                        var inputRow = Convert.ToChar(Console.ReadLine()!);
                        Console.Write("Enter Seat Column (e.g. 1): ");
                        var inputColumn = Convert.ToInt32(Console.ReadLine()!);
                        BookingManager.ReserveGoldSeatForScreen2(char.ToUpper(inputRow), inputColumn);
                        
                        continue;

                    case 1:
                        Console.Write("Enter number of tickets (between 1 to 3) :");
                        var inputTickets = Convert.ToInt32(Console.ReadLine()!);
                        BookingManager.ReserveSilverSeatForScreen2(inputTickets);
                        continue;
                    case 2:
                        ShowMoviesMenu(loggedUser);
                        break;
                    case 3:
                        MainMenu.Start(loggedUser);
                        break;
                    case 4:
                        CinemaBanner.PrintBanner();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"System Message: {e.Message}");
            Console.ResetColor();
            StartBookingScreen2(loggedUser);
        }

    }
}