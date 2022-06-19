namespace Cinnamon_Cinema_Movie_Theatre.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Movie()
    {
        
    }
    
}