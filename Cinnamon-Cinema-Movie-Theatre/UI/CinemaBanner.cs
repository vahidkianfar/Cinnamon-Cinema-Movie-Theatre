namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class CinemaBanner
{
    private const string GoodbyeMessage = @"
                                     |
                          ___________I____________
                         ( _____________________ ()
                       _.-'|                    ||
                   _.-'   || The First rule of  ||
               _.-'       ||   Fight Club is:   ||
  ______       _.-'       ||                    ||
 |      |_ _.-'           ||  You Don't Talk    ||
 |      |_|_              ||       about        ||
 |______|   `-._          ||                    ||
    /\          `-._      ||     Fight Club     ||
   /  \             `-._  ||                    ||
  /    \                `-.I____________________||
 /      \                 ------------------------
/________\___________________/________________\______                                                                                                                                               
";
    public const string StartLogo = @"
                                     |
                          ___________I____________
                         ( _____________________ ()
                       _.-'|                    ||
                   _.-'   ||                    ||
                _.-'      ||                    ||
  ______       _.-'       ||                    ||
 |      |_ _.-'           ||                    ||
 |      |_|_              ||                    ||
 |______|   `-._          ||                    ||
    /\          `-._      ||                    ||
   /  \             `-._  ||                    ||
  /    \                `-.I____________________||
 /      \                 ------------------------
/________\___________________/________________\______                                                                                                                                               
";
    public static void PrintBanner()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(GoodbyeMessage);
    }
}