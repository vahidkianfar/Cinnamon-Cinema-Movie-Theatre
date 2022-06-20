# Cinnamon-Cinema-Movie-Theatre


1. There is one database that stored "Movies", "Seats", "Users" , "top250_movies"
2. We have two screens at our Cinema, each screen shows different movie:

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/TwoScreen.gif)

3. We scraped IMDb top 250 movies (https://www.imdb.com/chart/top) and stored them into a table, so user can search see the movie's information.
   such as, Rank, Rate, Director, Casts, and etc.
   
![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/IMDb250Top.gif)
   
4. "BookingManager" class, Handles the User's requests.
5. Everytime that you start the program, All seatStatuses on the database reset to Free.


### User must login/register first:

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema-Login-Register.gif)

### We have two kinds of Seats:
1. Gold seat: User can choose Any Available seats.
2. Silver Seats (based on KATA) : Automatically assigned first available seats (maximum of 3 seats)
   (if first user buy a gold seat and choose A2 and the second user wants 3 silver seats, Booking Manager will assigned A1,A3,A4 for the second user)

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema.gif)
 
### No Available Seats:

   ![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema-NoAvailableSeats.gif)
   
