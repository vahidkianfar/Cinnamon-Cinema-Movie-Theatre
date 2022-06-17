using Cinnamon_Cinema_Movie_Theatre.Manager;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class MainMenu
{
    public async Task Start()
    {
        var selectInstructionOption = ConsoleHelper.MultipleChoice(true, "1. See the Available Seats",
            "2. ---", "3. Exit");

        switch (selectInstructionOption)
        {
            case 0:
            {
                await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
                await connectionToDatabase.OpenAsync();
                var seatDetails = new SeatManager(connectionToDatabase);
                await SeatManager.GetAvailableSeats(seatDetails);
                var drawTable = new DrawSeatsTable();
                await drawTable.LiveTable(seatDetails.SeatsStatus);

                var subMenu = new SubMenu();
                await subMenu.Start();
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