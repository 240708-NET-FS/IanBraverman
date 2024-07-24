using Project1App.DAO;
using Project1App.Service;
using Project1App.Utility;
using Project1App.Utility.Exceptions;

namespace Project1App.Controller;

public class PlayerController
{
    private PlayerService playerService;

    public PlayerController(PlayerService service)
    {
        playerService = service;
    }

    public bool NewGameOrRegister()
    {
        Console.WriteLine("Would you like to continue your current game or start a new one?");
        Console.WriteLine("Please enter N for new game, or C to continue your prior game: ");

        string input = Console.ReadLine();

        while (true)
        {
            switch (input)
            {
                case "N":
                case "n":
                case "New":
                case "new":
                    //then the current room becomes 0 for player. 0 means no game.
                    var updates = new Dictionary<string, object>
                    {
                        {"CurrentRoom", 0},
                        {"Health", 5},
                    };
                    playerService.UpdateFields(updates);
                    return true;
                case "C":
                case "c":
                case "Continue":
                case "continue":
                    //continue current game
                    return false;
                default:
                    Console.WriteLine("Please enter a valid answer");
                    break;
            }

        }
    }

    public void NewPlayer()
    {
        Console.WriteLine("Now that you have registered, it is time for you to create your Player Profile");
        Console.WriteLine("What is your first name: ");

        string firstname = Console.ReadLine();

        Console.WriteLine("What is your last name: ");

        string lastname = Console.ReadLine();

        try
        {
            playerService.RegisterNewPlayer(firstname, lastname, State.currentLogin.LoginId, State.currentLogin);
        }
        catch (LoginException e)
        {
            Console.WriteLine(e.Message);
        }


    }
}