using Cinnamon_Cinema_Movie_Theatre.Manager;

namespace Cinnamon_Cinema_Movie_Theatre.Models;

public class User
{
  

    public string UserName { get; set; }
    private string Password { get; set; }
    public string? Email { get; set; }
    private List<Movie> Movies { get; set; }
    private List<Seat> Seats { get; set; }
    
    public User( string userName)
    {
        UserName = userName;
    }
    public void BuyTicket(Movie movie, Seat seat)
    {
        Movies.Add(movie);
        Seats.Add(seat);
        var connectionToDatabase = IDatabase.Connection.GetConnection();
        connectionToDatabase.Open();
        UserManager.SetConnection(connectionToDatabase);
    }
}