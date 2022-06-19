using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre;

public interface IDatabase
{

const string ConnectionInitializer = "Host=localhost;" +
                                     "Username=postgres;" +
                                     "Password=johnybravo;" +
                                     "Database=CinnamonCinemas";


const string ConnectionInitializerTo250Movies = "Host=localhost;" +
                                     "Username=postgres;" +
                                     "Password=johnybravo;" +
                                     "Database=postgres";
public partial class Connection
{
    public static NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(ConnectionInitializer);
    }
}

}
