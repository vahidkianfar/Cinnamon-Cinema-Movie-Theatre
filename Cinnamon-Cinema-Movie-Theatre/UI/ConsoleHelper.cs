using Cinnamon_Cinema_Movie_Theatre.Manager;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.UI;


public class ConsoleHelper
{
    
    public static int MultipleChoice(bool canCancel, params string[] options)
    {
        using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        const int startX = 35;
        const int startY = 9;
        const int optionsPerLine = 1;
        const int spacingPerLine = 14;
        var currentSelection = 0;
        Console.CursorVisible = false;
        ConsoleKey key;

        do 
        {
            connectionToDatabase.Open();
            SeatManager.SetConnection(connectionToDatabase);
            var seatsStatusScreen1=SeatManager.GetAvailableSeatsOfScreen1();
            var seatsStatusScreen2=SeatManager.GetAvailableSeatsOfScreen2();
            var drawTableScreen1 = new DrawSeatsTable();
            var drawTableScreen2 = new DrawSeatsTable();
            Console.WriteLine();
            #pragma warning disable CS4014
            drawTableScreen1.LiveTableScreen1(seatsStatusScreen1);
            drawTableScreen2.LiveTableScreen2(seatsStatusScreen2);
            #pragma warning restore CS4014
            connectionToDatabase.Close();
            Console.ResetColor();
            for (var optionCounter = 0; optionCounter < options.Length; optionCounter++)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(startX + (optionCounter % optionsPerLine) * spacingPerLine, startY + optionCounter / optionsPerLine);
                if (optionCounter == currentSelection)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(options[optionCounter]);
                Console.ResetColor();
            }
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if (currentSelection % optionsPerLine > 0)
                        currentSelection--;
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (currentSelection % optionsPerLine < optionsPerLine - 1)
                        currentSelection++;
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (currentSelection >= optionsPerLine)
                        currentSelection -= optionsPerLine;
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (currentSelection + optionsPerLine < options.Length)
                        currentSelection += optionsPerLine;
                    break;
                }
                case ConsoleKey.Escape:
                {
                    if (canCancel)
                        return -1;
                    break;
                }
            }
            Console.Clear();
        } while (key != ConsoleKey.Enter);
        Console.CursorVisible = true;
        return currentSelection;
    }
}