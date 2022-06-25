# Cinnamon-Cinema-Movie-Theatre

### NOTE:

1.**You Need PostgreSQL on your machine**
2. Binary Backup of the Database is in the root folder of the project: **CinnamonCinemasBackup**
3.for the fist run just uncomment **DatabaseManager.CreateDatabase();** in Program.cs and then run the following line within your terminal:

* **pg_restore -h localhost -p 5432 -U postgres -c -d cinnamoncinemas CinnamonCinemaBackup**

### Details:
1. There is one database that stores "Movies", "Screens", "Users" , "top250_movies"
2. The Cinnema has two screens, each screen shows different movie (user can book separately):

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/TwoScreens.gif)

3. Admin has many privileges to Add/Update/Delete Movies, Screens and etc:

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/AdminMenu.gif)

4. I scraped IMDb top 250 movies (https://www.imdb.com/chart/top) and stored them into a table, so user can search and see the movie's information.
   such as, Rank, Rate, Director, Casts, and etc.
   
![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/IMDb250Top.gif)
   
5. "BookingManager" class, Handles the User's requests.
6. Everytime that you start the program, All seatStatuses on the database reset to Free.


### User must login/register first:

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema-Login-Register.gif)

### We have two kinds of Seats:
1. Gold seat: User can choose Any Available seats.
2. Silver Seats (based on KATA) : Automatically assigned first available seats (maximum of 3 seats)
   (if first user buy a gold seat and choose A2 and the second user wants 3 silver seats, Booking Manager will assigned A1,A3,A4 for the second user)

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema.gif)
 
### No Available Seats:

   ![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema-NoAvailableSeats.gif)
   
