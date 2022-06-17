using Npgsql;
using Cinnamon_Cinema_Movie_Theatre;

await using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
await connectionToDatabase.OpenAsync();

// var movieDetails = new Movies();
// await Movies.GetMovieTitle(movieDetails);

// foreach (var title in movieDetails.Title)
//     Console.WriteLine(title);

var seatDetails = new SeatManager(connectionToDatabase);
await SeatManager.GetAvailableSeats(seatDetails);

// foreach(var status in seatDetails.SeatsStatus)
//     Console.WriteLine(status.Item1 + " " + status.Item2);


//Working UpdateSeatStatus

//await SeatManager.UpdateSeatStatus('B', 3, 1);

var drawTable= new DrawSeatsTable();
await drawTable.LiveTable(seatDetails.SeatsStatus);