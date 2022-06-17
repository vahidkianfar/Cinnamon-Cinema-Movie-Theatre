﻿using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class BookingManager
{
    public static NpgsqlConnection? _connection { get; set; }
    public BookingManager(NpgsqlConnection? connection)=>_connection = connection;
    public static void ReserveSilverSeat(int numberOfSeats)
    {
        var randomSeatNumber=new Random();
        var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connectionToDatabase.Open();
        SeatManager._connection = connectionToDatabase;
        SeatManager.GetAvailableSeats();
        //numberOfSeats=randomSeatNumber.Next(1,4);
        var allocated = 0;
        var colCounter = 0;
        for (var rowCounter = 0; rowCounter < 15; rowCounter++)
        {
            if (numberOfSeats == allocated) break;
            if (SeatManager.SeatsStatus[rowCounter].Item3 == 0)
            {
                SeatManager.UpdateSeatStatus(Convert.ToChar(SeatManager.SeatsStatus[rowCounter].Item1),
                    colCounter+1, 1);
                allocated++;
                
            }
            colCounter++;
            if (colCounter==5) colCounter=0;
        }
        
        //connectionToDatabase.Close();
    }
    public static void ReserveGoldSeat(char rowBlock, int seatNumber)
    {
        var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connectionToDatabase.Open();
        SeatManager._connection = connectionToDatabase;
        SeatManager.UpdateSeatStatus(rowBlock, seatNumber, 1);
        connectionToDatabase.Close();
    }
    public static void ResetSeats()
    {
        var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connectionToDatabase.Open();
        SeatManager._connection= connectionToDatabase;
        SeatManager.GetAvailableSeats();
        foreach (var status in SeatManager.SeatsStatus)
            SeatManager.UpdateSeatStatus(Convert.ToChar(status.Item1), status.Item2,0);
        connectionToDatabase.Close();
    }
}