namespace Cinnamon_Cinema_Movie_Theatre.Models;

public class Seat
{
    private int SeatId { get; set; }
    public char Row { get; set; }
    public int Column { get; set; }

    public Seat(char row, int column)
    {
        Row = row;
        Column = column;
    }
}