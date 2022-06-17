using Cinnamon_Cinema_Movie_Theatre.Manager;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class SubMenu
{
    public async Task Start()
    {
        var selectInstructionOption = ConsoleHelper.MultipleChoice(true, "1. Book a Seat",
            "2. ---", "3. Exit");
        await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        await connectionToDatabase.OpenAsync();
        var seatDetails = new SeatManager(connectionToDatabase);
        await SeatManager.GetAvailableSeats(seatDetails);
        var drawTable = new DrawSeatsTable();
        await drawTable.LiveTable(seatDetails.SeatsStatus);
        switch (selectInstructionOption)
        {
            case 0:
            {
                Console.WriteLine("Enter number of seats to book");
                break;
            }
            case 1:
                Console.WriteLine("2. ---");
                break;
            case 2:
                Environment.Exit(0);
                break;
        }
    }
}