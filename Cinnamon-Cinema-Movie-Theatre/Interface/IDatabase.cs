using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre;

public interface IDatabase
{

const string ConnectionInitializer = "Host=localhost;" +
                                     "Username=postgres;" +
                                     "Password=johnybravo;" +
                                     "Database=CinnamonCinemas";


}
