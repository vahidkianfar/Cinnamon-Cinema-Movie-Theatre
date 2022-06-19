using Cinnamon_Cinema_Movie_Theatre.Manager;
using Cinnamon_Cinema_Movie_Theatre.Models;
using Npgsql;

namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class MainMenu
{
    public static void Start()
    {
        //Console.Clear();
        var selectInstructionOption = ConsoleHelper.MultipleChoice(true, "1. See Available Movies",
            "2. Exit");
        switch (selectInstructionOption)
        {
            case 0:
            {
                SubMenu.ShowMoviesMenu();
                break;
            }
            
            case 1:
                Environment.Exit(0);
                break;
        }
    }
}