using Cinnamon_Cinema_Movie_Theatre;
using Cinnamon_Cinema_Movie_Theatre.Manager;
using Npgsql;
using Cinnamon_Cinema_Movie_Theatre.UI;

public class SubMenu
{
    public static void ShowMoviesMenu()
    {
        var connectionToDatabase = IDatabase.Connection.GetConnection();
        connectionToDatabase.Open();
        MovieManager.SetConnection(connectionToDatabase);
        MovieManager.GetMovieDetails();

        var selectInstructionOption = ConsoleHelper.MultipleChoice(true,
            $"1. Title: {MovieManager.MovieDetails![0].Item2} (Directed by {MovieManager.MovieDetails[0].Item3})",
            "2. Back", "3. Exit");
        connectionToDatabase.Close();

        switch (selectInstructionOption)
        {
            case 0:
                StartBooking();
                break;
            case 1:
                MainMenu.Start();
                break;
            case 2:
                CinemaBanner.PrintBanner();
                Environment.Exit(0);
                break;
        }
    }

    
    private static void StartBooking()
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
                        BookingManager.ReserveGoldSeat(char.ToUpper(inputRow), inputColumn);
                        continue;

                    case 1:
                        Console.Write("Enter number of tickets (between 1 to 3) :");
                        var inputTickets = Convert.ToInt32(Console.ReadLine()!);
                        BookingManager.ReserveSilverSeat(inputTickets);
                        continue;
                    case 2:
                        ShowMoviesMenu();
                        break;
                    case 3:
                        MainMenu.Start();
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
            StartBooking();
        }

    }
}