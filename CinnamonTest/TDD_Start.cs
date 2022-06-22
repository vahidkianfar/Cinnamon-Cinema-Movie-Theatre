using Cinnamon_Cinema_Movie_Theatre;
using Cinnamon_Cinema_Movie_Theatre.Manager;
using Npgsql;

namespace CinnamonTest;
using NUnit.Framework;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Database_Connection_Should_Be_Open()
    {
        var connection = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connection.Open();
        Assert.That(connection.State, Is.EqualTo(System.Data.ConnectionState.Open));
    }
    [Test]
    public void Database_Connection_Should_Be_Close()
    {
        var connection = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connection.Open();
        connection.Close();
        Assert.That(connection.State, Is.EqualTo(System.Data.ConnectionState.Closed));
    }

    [Test]
    public void UserManager_Should_Be_Able_To_Create_A_User_And_Retrieve_It()
    {
     
        var connection = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connection.Open();
        UserManager.SetConnection(connection);
        var testUsername = "John";
        //var password = "12345";
        
        // Because usernames are unique, we need to create a new username to test with
        //var register = UserManager.Register(username, password);

        var cmd = new NpgsqlCommand("SELECT * FROM users WHERE username=@username",
                connection);
        cmd.Parameters.AddWithValue("@username", testUsername);
        var reader = cmd.ExecuteReader();
        var readFromDatabase="";
        while (reader.Read())
            readFromDatabase=reader.GetString(0);
        
        Assert.That(readFromDatabase, Is.EqualTo(testUsername));
    }
    
    [Test]
    
    public void IDatabase_Should_Connect_To_Database()
    {
        using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connectionToDatabase.Open();
        Assert.That(connectionToDatabase.State, Is.EqualTo(System.Data.ConnectionState.Open));
    }
    [Test]
    
    public void MovieManager_Should_Return_Movie_by_Search()
    {
        using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        connectionToDatabase.Open();
        MovieManager.SetConnection(connectionToDatabase);
        MovieManager.SearchMovies("The Godfather");
        Assert.That(connectionToDatabase.State, Is.EqualTo(System.Data.ConnectionState.Open));
    }
}