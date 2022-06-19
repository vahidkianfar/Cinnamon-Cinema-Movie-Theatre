using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.Manager;

public class DatabaseManager
{
    public static void CreateDatabase()
    {
        try
        {
            // Create the database if it doesn't exist
            string connStr = "Server=localhost;Port=5432;User Id=postgres;Password=johnybravo;";
            var m_conn = new NpgsqlConnection(connStr);
            var m_createdb_cmd = new NpgsqlCommand(@"CREATE DATABASE CinnamonCinemas", m_conn);
            
            m_conn.Open();
            m_createdb_cmd.ExecuteNonQuery();
            m_conn.Close();
            CreateTables();
        }
        

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void CreateTables()
    {
        try
        {
            var connStr = "Server=localhost;Port=5432;User Id=postgres;Password=johnybravo;Database=CinnamonCinemas;";
            var m_conn = new NpgsqlConnection(connStr);
            m_conn = new NpgsqlConnection(connStr);
            var m_createTableMovie_cmd = new NpgsqlCommand(
                "CREATE TABLE movies(genre TEXT, title TEXT, director TEXT)", m_conn);
            var m_createTableSeats_cmd = new NpgsqlCommand(
                "CREATE TABLE movies(rowblock TEXT, columnnumber INTEGER, status INTEGER)", m_conn);
            m_conn.Open();
            m_createTableMovie_cmd.ExecuteNonQuery();
            m_createTableSeats_cmd.ExecuteNonQuery();
        
            var movieInsert = new NpgsqlCommand(
                "INSERT INTO movies(genre, title, director) VALUES('Drama/Fantasy', 'The Seventh Seal', 'Ingmar Bergman')", m_conn);
            movieInsert.ExecuteNonQuery();
        
            var seatsInsert = new NpgsqlCommand(
                "INSERT INTO seats(rowblock, columnnumber, status) VALUES" +
                "('A', 1, 0)"
                + ",('A', 2, 0)"
                + ",('A', 3, 0)"
                + ",('A', 4, 0)"
                + ",('A', 5, 0)"
                + ",('B', 1, 0)"
                + ",('B', 2, 0)"
                + ",('B', 3, 0)"
                + ",('B', 4, 0)"
                + ",('B', 5, 0)"
                + ",('C', 1, 0)"
                + ",('C', 2, 0)"
                + ",('C', 3, 0)"
                + ",('C', 4, 0)"
                + ",('C', 5, 0)"
                , m_conn);
            seatsInsert.ExecuteNonQuery();
            m_conn.Close();
        }   
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}