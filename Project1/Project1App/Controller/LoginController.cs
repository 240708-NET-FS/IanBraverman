using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;
using Project1App.Utility.Exceptions;

namespace Project1App.Controller;

public class LoginController
{

    private LoginService loginService;

    private PlayerService playerService;

    public LoginController(LoginService loginservice, PlayerService playerservice)
    {
        loginService = loginservice;
        playerService = playerservice;
    }



    public void Login()
    {


        bool loggedIn = false;

        while (loggedIn == false)
        {
            Console.WriteLine("Please log in below");
            Console.WriteLine("Please enter your username below: ");

            string username = Console.ReadLine();

            Console.WriteLine("Please enter your password: ");

            string password = Console.ReadLine();
            try
            {
                {
                    Login login = loginService.Login(username, password);
                    if (login != null)
                    {
                        State.currentPlayer = playerService.GetByLoginID();
                        Console.WriteLine("the current login is " + State.currentLogin.LoginId);

                        Console.WriteLine("The current player is: " + State.currentPlayer);

                        // Console.WriteLine("Do you want to quit? Please type Y or N");

                        // string input = Console.ReadLine();

                        // switch (input)
                        // {
                        //     case "y":
                        //     case "Y":
                        //         State.isActive = false;
                        //         break;
                        //     case "N":
                        //     case "n":
                        //         break;
                        //     default:
                        //         Console.WriteLine("Invalid Input");
                        //         break;
                        // }
                        loggedIn = true;
                    }
                    // else
                    // {
                    //     Console.WriteLine("Please try logging in again");
                    //     continue;
                    // }
                }
            }
            catch (LoginException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public void Register()

    {
        bool registered = false;
        while (!registered)
        {
            Console.WriteLine("Please Register Below");
            Console.WriteLine("Please enter your new username below: ");

            string username = Console.ReadLine();

            Console.WriteLine("Please enter your new password below: ");

            string password = Console.ReadLine();

            try
            {
                loginService.Register(username, password);
                registered = true;
            }
            catch (LoginException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}