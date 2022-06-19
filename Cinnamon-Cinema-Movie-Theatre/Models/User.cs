namespace Cinnamon_Cinema_Movie_Theatre.Models;

public class User
{
    public User(int userId, string userName, string password, string email)
    {
        UserId = userId;
        UserName = userName;
        Password = password;
        Email = email;
    }

    private int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}