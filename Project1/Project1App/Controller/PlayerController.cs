using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;
using Project1App.Utility.Exceptions;

namespace Project1App.Controller;

public class PlayerController
{
    private PlayerService playerService;

    private PlayerItemsService playerItemsService;

    public PlayerController(PlayerService service, PlayerItemsService playeritemservice)
    {
        playerService = service;
        playerItemsService = playeritemservice;
    }

    public bool NewGameOrContinue()
    {
        Console.WriteLine($"Hello {State.currentPlayer.FirstName}, would you like to continue your current game or start a new one?");
        if (State.currentPlayer.CurrentRoom > 0)
        {
            Console.WriteLine($"You are currently on level {State.currentPlayer.CurrentRoom}");
        }
        Console.WriteLine("Please enter N for new game, or C to continue your prior game: ");

        string input = Console.ReadLine();

        //this clears everything previously on the console making the game more readable
        Console.Clear();

        while (true)
        {
            switch (input)
            {
                case "N":
                case "n":
                case "New":
                case "new":
                    //then the current room becomes 0 for player. 0 means no game.
                    var updatesPlayer = new Dictionary<string, object>
                    {
                        {"CurrentRoom", 0},
                        {"Health", 5},
                    };
                    playerService.UpdateFields(updatesPlayer);
                    var resetsPlayerItems = new Dictionary<string, object>
                    {
                        {"Sword", 0 },
                        {"Shield", 0 },
                        {"Armor", 0 },
                        {"Helmet", 0 },
                        {"DungeonKey", 0 },
                    };
                    playerItemsService.UpdateFields(resetsPlayerItems);
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