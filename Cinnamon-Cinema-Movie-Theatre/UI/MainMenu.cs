using Cinnamon_Cinema_Movie_Theatre.Models;

namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class MainMenu
{
    public static void Start(User loggedUser)
    {
        //Console.Clear();
        if (loggedUser.UserName == "admin")
            AdminMenu.Start();
        var selectInstructionOption = ConsoleHelper.MultipleChoice(true, "1. See Available Movies", "2. Logout",
            "3. Exit");
        switch (selectInstructionOption)
        {
            case 0:
                SubMenu.ShowMoviesMenu(loggedUser);
                break;
            
            case 1:
                UserMenu.Start();
                break;
            
            case 2:
                CinemaBanner.PrintBanner();
                Environment.Exit(0);
                break;
        }
    }
}