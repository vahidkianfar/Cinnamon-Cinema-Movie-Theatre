namespace Cinnamon_Cinema_Movie_Theatre.Models;

public class Movie
{
    private int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Movie(string title, string genre, string director)
    {
        Title = title;
        Genre = genre;
        Director = director;
    }
    
}