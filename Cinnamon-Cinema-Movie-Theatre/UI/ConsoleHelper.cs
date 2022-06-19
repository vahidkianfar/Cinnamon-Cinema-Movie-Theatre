using Cinnamon_Cinema_Movie_Theatre;
using Cinnamon_Cinema_Movie_Theatre.Manager;
using Cinnamon_Cinema_Movie_Theatre.Models;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.UI;


public class ConsoleHelper
{
    
    public static int MultipleChoice(bool canCancel, params string[] options)
    {
        using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
        const int startX = 0;
        const int startY = 13;
        const int optionsPerLine = 1;
        const int spacingPerLine = 14;
        var currentSelection = 0;
        Console.CursorVisible = false;
        ConsoleKey key;

        do 
        {
            connectionToDatabase.Open();
            SeatManager.SetConnection(connectionToDatabase);
            var seatsStatus=SeatManager.GetAvailableSeats();
            var drawTable = new DrawSeatsTable();
#pragma warning disable CS4014
            drawTable.LiveTable(seatsStatus);
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