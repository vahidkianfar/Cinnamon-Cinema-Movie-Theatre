using System.Configuration;
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
                        using var connectionToDatabase = IDatabase.Connection.GetConnection();
                        connectionToDatabase.Open();
                        var selectInstructionOption = ConsoleHelper.MultipleChoiceForStartingMenu(true, "1. Login", "2. Register", "3. Exit");
                        switch (selectInstructionOption)
                        {
                            case 0:
                            {
                                Console.Write("Enter your username: ");
                                string username = Console.ReadLine()!;
                                string password=AnsiConsole.Prompt(new TextPrompt<string>("Enter [green]password[/]: ").PromptStyle("red").Secret());
                                var loggeduser = new User(username);
                                UserManager.SetConnection(connectionToDatabase);
                                var userChecker = UserManager.Login(username, password);

                                if (userChecker)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Login successful!, Welcome " + username);
                                    Console.ResetColor();
                                    var loggedUser = new User(username);
                                    MainMenu.Start(loggedUser);
                                }
                               
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
                                Console.Write("Enter a Username: ");
                                string usernameRegister = Console.ReadLine()!;
                                Console.Write("Enter a Password: ");
                                string passwordRegister = Console.ReadLine()!;
                                Console.Write("Enter an Email: ");
                                string emailRegister = Console.ReadLine()!;
                                UserManager.SetConnection(connectionToDatabase);
                                var register = UserManager.Register(usernameRegister, passwordRegister, emailRegister);
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
                                CinemaBanner.PrintBanner();
                                Environment.Exit(0);
                                break;
                        }
            
                        break;
            }

        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"System Message: Username already exists");
            Console.ResetColor();
            Start();
        }
    }
}