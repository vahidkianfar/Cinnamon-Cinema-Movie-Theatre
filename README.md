# Cinnamon-Cinema-Movie-Theatre

#Initial Approach:
1. There is one database that stored "Movies", "Seats", "Users"
2. "BookingManager" class, Handles the User's requests.
3. Everytime that you start the program, All seatStatuses on the database reset to Free.

### User must login/register first:

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema-Login-Register.gif)

### We have two kinds of Seats:
1. Gold seat: User can choose Any Available seats.
2. Silver Seats (based on KATA) : Automatically assigned first available seats (maximum of 3 seats)
   (if first user buy a gold seat and choose A2 and the second user wants 3 silver seats, Booking Manager will assigned A1,A3,A4 for the second user)

![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema.gif)
 
### No Available Seats:

   ![](https://github.com/vahidkianfar/Cinnamon-Cinema-Movie-Theatre/blob/master/Cinnamon-Cinema-Movie-Theatre/Gif/CinnamonCinema-NoAvailableSeats.gif)
   
