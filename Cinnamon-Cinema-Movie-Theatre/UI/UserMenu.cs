using Cinnamon_Cinema_Movie_Theatre.Manager;
using Cinnamon_Cinema_Movie_Theatre.Models;
using Npgsql;
using Spectre.Console;
namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class UserMenu
{
    public static void Start()
    {
        try
        {
            while (true)
            {
                        //Console.Clear();
                        using var connectionToDatabase = new NpgsqlConnection(IDatabase.ConnectionInitializer);
                        connectionToDatabase.Open();
                        var selectInstructionOption = ConsoleHelper.MultipleChoice(true, "1. Login", "2. Register", "3. Exit");
                        switch (selectInstructionOption)
                        {
                            case 0:
                            {
                                Console.Write("Enter your username: ");
                                string username = Console.ReadLine()!;
                                Console.Write("Enter your password: ");
                                string password = Console.ReadLine()!;
            
                                
                                UserManager.SetConnection(connectionToDatabase);
                                var userChecker = UserManager.Login(username, password);
            
                                if (userChecker)
                                    MainMenu.Start();
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid username or password");
                                    Console.ResetColor();
                                }
                                continue;
                            }
            
                            case 1:
                            {
                                Console.Write("Enter your username: ");
                                string usernameRegister = Console.ReadLine()!;
                                Console.Write("Enter your password: ");
                                string passwordRegister = Console.ReadLine()!;
                                UserManager.SetConnection(connectionToDatabase);
                                var register = UserManager.Register(usernameRegister, passwordRegister);
                                if (register)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Successfully registered");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Username already exists");
                                    Console.ResetColor();
                                }
                                continue;
                            }
            
                            case 2:
                                Environment.Exit(0);
                                break;
                        }
            
                        break;
            }

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"System Message: Username already exists");
            Console.ResetColor();
            Start();
        }
    }
}