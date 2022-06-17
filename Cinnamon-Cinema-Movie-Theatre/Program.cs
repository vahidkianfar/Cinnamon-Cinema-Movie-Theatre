﻿using Npgsql;
using Cinnamon_Cinema_Movie_Theatre;

// const string connectionInitializer = "Host=localhost;" +
//                                      "Username=postgres;" +
//                                      "Password=johnybravo;" +
//                                      "Database=CinnamonCinemas";
//
// await using var connectionToDatabase = new NpgsqlConnection(connectionInitializer);
// await connectionToDatabase.OpenAsync();
//
// await using (var cmd = new NpgsqlCommand("SELECT title FROM movies", connectionToDatabase))
// await using (var reader = await cmd.ExecuteReaderAsync()) 
// {
//     Console.WriteLine();
//
//     while (await reader.ReadAsync())
//     {
//         Console.WriteLine(reader.GetString(0));
//     }
// }



var movieDetails = new Movies();
await Movies.GetMovieTitle(movieDetails);

foreach (var title in movieDetails.Title)
    Console.WriteLine(title);

var seatDetails = new SeatManager();
await SeatManager.GetAvailableSeats(seatDetails);

foreach(var status in seatDetails.seatsStatus)
    Console.WriteLine(status.Item1 + " " + status.Item2);
    
// var drawTable= new DrawSeatsTable();
// await drawTable.LiveTable(seatDetails.seatsStatus);

await SeatManager.UpdateSeatStatus('A', 1, 1);