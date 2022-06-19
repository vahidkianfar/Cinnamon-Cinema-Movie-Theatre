namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class CinemaBanner
{
    public const string GoodbyeMessage = @"
                                     |
                          ___________I____________
                         ( _____________________ ()
                       _.-'|                    ||
                   _.-'   ||      Cinnamon      ||
  ______       _.-'       ||                    ||
 |      |_ _.-'           ||       Cinema       ||
 |      |_|_              ||                    ||
 |______|   `-._          ||       Movie        ||
    /\          `-._      ||                    ||
   /  \             `-._  ||      Theatre       ||
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