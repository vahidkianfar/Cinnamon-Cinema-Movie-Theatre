using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class BookingManager
{
    private static NpgsqlConnection? _connection { get; set; }
    public BookingManager(NpgsqlConnection? connection)=>_connection = connection;
    public static void SetConnection(NpgsqlConnection? connection)=>_connection = connection;
    public static void ReserveSilverSeatForScreen1(int numberOfSeats)
    {
        if (numberOfSeats > 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSystem Message: You can only reserve maximum 3 seats at once");
            Console.ResetColor();
            return;
        }
        var randomSeatNumber=new Random();
        var connectionToDatabase = IDatabase.Connection.GetConnection();;
        connectionToDatabase.Open();
        SeatManager.SetConnection(connectionToDatabase);
        SeatManager.GetAvailableSeatsOfScreen1();
        var allocated = 0;
        var colCounter = 0;
        for (var rowCounter = 0; rowCounter < 15; rowCounter++)
        {
            if (numberOfSeats == allocated) break;
            if (SeatManager.SeatsStatus![rowCounter].Item3 == 0)
            {
                SeatManager.UpdateSeatStatusForScreen1(Convert.ToChar(SeatManager.SeatsStatus[rowCounter].Item1),
                    colCounter+1, 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Seat Reserved: " + SeatManager.SeatsStatus[rowCounter].Item1 +
                                  SeatManager.SeatsStatus[rowCounter].Item2);
                allocated++;
            }
            colCounter++;
            if (colCounter==5) colCounter=0;
        }
        if (allocated == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n System Message: **No seats available**");
            Console.ResetColor();
            return;
        }
        Console.ResetColor();
        connectionToDatabase.Close();
    }
    public static void ReserveSilverSeatForScreen2(int numberOfSeats)
    {
        if (numberOfSeats > 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSystem Message: You can only reserve maximum 3 seats at once");
            Console.ResetColor();
            return;
        }
        var randomSeatNumber=new Random();
        var connectionToDatabase = IDatabase.Connection.GetConnection();;
        connectionToDatabase.Open();
        SeatManager.SetConnection(connectionToDatabase);
        SeatManager.GetAvailableSeatsOfScreen2();
        var allocated = 0;
        var colCounter = 0;
        for (var rowCounter = 0; rowCounter < 15; rowCounter++)
        {
            if (numberOfSeats == allocated) break;
            if (SeatManager.SeatsStatus![rowCounter].Item3 == 0)
            {
                SeatManager.UpdateSeatStatusForScreen2(Convert.ToChar(SeatManager.SeatsStatus[rowCounter].Item1),
                    colCounter+1, 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Seat Reserved: " + SeatManager.SeatsStatus[rowCounter].Item1 +
                                  SeatManager.SeatsStatus[rowCounter].Item2);
                allocated++;
            }
            colCounter++;
            if (colCounter==5) colCounter=0;
        }
        if (allocated == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n System Message: **No seats available**");
            Console.ResetColor();
            return;
        }
        Console.ResetColor();
        connectionToDatabase.Close();
    }
    public static void ReserveGoldSeatForScreen1(char rowBlock, int seatNumber)
    {
        var connectionToDatabase = IDatabase.Connection.GetConnection();
        connectionToDatabase.Open();
        SeatManager.SetConnection(connectionToDatabase);
        SeatManager.UpdateSeatStatusForScreen1(rowBlock, seatNumber, 1);
        connectionToDatabase.Close();
    }
    public static void ReserveGoldSeatForScreen2(char rowBlock, int seatNumber)
    {
        var connectionToDatabase = IDatabase.Connection.GetConnection();
        connectionToDatabase.Open();
        SeatManager.SetConnection(connectionToDatabase);
        SeatManager.UpdateSeatStatusForScreen2(rowBlock, seatNumber, 1);
        connectionToDatabase.Close();
    }
    public static void ResetSeats()
    {
        var connectionToDatabase = IDatabase.Connection.GetConnection();
        connectionToDatabase.Open();
        SeatManager.SetConnection(connectionToDatabase);
        SeatManager.GetAvailableSeatsOfScreen1();
        foreach (var status in SeatManager.SeatsStatus!)
            SeatManager.UpdateSeatStatusForScreen1(Convert.ToChar(status.Item1), status.Item2,0);
        SeatManager.GetAvailableSeatsOfScreen2();
        foreach (var status in SeatManager.SeatsStatus!)
            SeatManager.UpdateSeatStatusForScreen2(Convert.ToChar(status.Item1), status.Item2,0);
        connectionToDatabase.Close();
    }
}