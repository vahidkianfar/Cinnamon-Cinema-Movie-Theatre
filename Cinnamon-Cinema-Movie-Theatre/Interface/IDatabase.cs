using Npgsql;
using System.Collections.Specialized;
using System.Configuration;

namespace Cinnamon_Cinema_Movie_Theatre;

public interface IDatabase
{
    

const string ConnectionInitializer = "Host=localhost;" +
                                     "Username=postgres;" +
                                     "Password=johnybravo;" +
                                     "Database=cinnamoncinemasnew";
public partial class Connection
{
    public static NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(ConnectionInitializer);
    }
}
}
