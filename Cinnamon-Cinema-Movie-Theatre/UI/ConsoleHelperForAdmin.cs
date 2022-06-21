
using System.Globalization;
using Spectre.Console;
using Calendar = Spectre.Console.Calendar;

namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class ConsoleHelperForAdmin
{

    public static int MultipleChoiceForAdmin(bool canCancel, params string[] options)
    {
        AnsiConsole.Progress()
            .Start(ctx => 
            {
                var task1 = ctx.AddTask("[green]Loading Database[/]");
                while(!ctx.IsFinished)
                    task1.Increment(0.00004);
            });

        const int startX = 45;
        const int startY = 3;
        const int optionsPerLine = 1;
        const int spacingPerLine = 14;
        var currentSelection = 0;
        Console.CursorVisible = false;
        ConsoleKey key;

        do 
        {
            AnsiConsole.Write(new Calendar(DateTime.Now).RoundedBorder()
                .Culture(CultureInfo.InvariantCulture));
            for (var optionCounter = 0; optionCounter < options.Length; optionCounter++)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(startX + (optionCounter % optionsPerLine) * spacingPerLine, startY + optionCounter / optionsPerLine);
                if (optionCounter == currentSelection)
                    Console.ForegroundColor = ConsoleColor.DarkRed;
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