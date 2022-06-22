using Cinnamon_Cinema_Movie_Theatre.Manager;
using Npgsql;
using Spectre.Console;

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
    public static int MultipleChoiceForStartingMenu(bool canCancel, params string[] options)
    {
        const int startX = 33;
        const int startY = 7;
        const int optionsPerLine = 1;
        const int spacingPerLine = 14;
        var currentSelection = 0;
        Console.CursorVisible = false;
        ConsoleKey key;

        do 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(CinemaBanner.StartLogo);
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
    public static int MultipleChoiceForAdmin(bool canCancel, params string[] options)
    {
        // AnsiConsole.Progress()
        //     .Start(ctx => 
        //     {
        //         var task1 = ctx.AddTask("[green]Loading Database[/]");
        //         while(!ctx.IsFinished)
        //             task1.Increment(0.00004);
        //     });
        

        const int startX = 47;
        const int startY = 3;
        const int optionsPerLine = 1;
        const int spacingPerLine = 14;
        var currentSelection = 0;
        Console.CursorVisible = false;
        ConsoleKey key;
        
        do 
        {
            Console.WriteLine();
            AnsiConsole.Write(new Calendar(DateTime.Now).AddCalendarEvent(DateTime.Today).BorderColor(Color.DarkOliveGreen2));
            for (var optionCounter = 0; optionCounter < options.Length; optionCounter++)
            {
                
                Console.CursorVisible = false;
                Console.SetCursorPosition(startX + (optionCounter % optionsPerLine) * spacingPerLine, startY + optionCounter / optionsPerLine);
                if (optionCounter == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Blue;
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