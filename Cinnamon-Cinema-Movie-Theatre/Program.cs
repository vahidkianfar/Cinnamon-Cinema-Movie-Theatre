using Cinnamon_Cinema_Movie_Theatre.Manager;
using Cinnamon_Cinema_Movie_Theatre.UI;

//******For the first time Just uncomment the below line:

//DatabaseManager.CreateDatabase();

//******and then run the below run within your terminal:

// "pg_restore -h localhost -p 5432 -U postgres -c -d cinnamoncinemas CinnamonCinemasBackup"


BookingManager.ResetSeats();
UserMenu.Start();

