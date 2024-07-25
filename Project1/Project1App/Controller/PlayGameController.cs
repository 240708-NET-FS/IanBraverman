using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;
using Project1App.Utility.Exceptions;
using Project1App.Controller;

namespace Project1App.Controller;

public class PlayGameController
{

    private PlayerItemsService playerItemsService;

    private PlayerService playerService;

    public PlayGameController(PlayerItemsService playeritemservice, PlayerService playerservice)
    {
        playerItemsService = playeritemservice;
        playerService = playerservice;
    }



    public void PlayRoomOne()
    {
        bool stillInRoom = true;
        Console.WriteLine("Why does my head hurt so bad? You slowly open your eyes and you are definitly not in kansas anymore.");
        Console.WriteLine("You look around and see that you are locked in a cold medieval dungeon cell.");
        Console.WriteLine("There is only one window, the walls are made of stone, and there is a big iron gate leading to the hallway; the only way out.");
        Console.WriteLine("You are in beat up tattered clothing. You check your pockets, and all of your items are gone.");
        Console.WriteLine("Where am I?");
        while (stillInRoom == true)
        {
            Console.WriteLine("Please pick one of the following options: ");
            Console.WriteLine("1: Look around the room for any clues or items that might help you");
            Console.WriteLine("2: Yell for help");
            Console.WriteLine("3: Try and escape through the gate");

            string playerInput = Console.ReadLine();



            switch (playerInput)
            {
                case "1":
                case "One":
                case "one":
                    Console.WriteLine("You look around the room and find a mysterious key...");
                    Console.WriteLine("I wonder what it opens?");
                    //make dungeon key 1 in their playeritems
                    var updatesKey = new Dictionary<string, object>
                    {
                        {"DungeonKey", 1},
                    };
                    playerItemsService.UpdateFields(updatesKey);
                    //this also gets current players playeritems and sets playeritems after being updated again
                    break;
                case "2":
                case "Two":
                case "two":
                    Console.WriteLine("You scream out for anyone that may hear you. 'HELP! HELP! HELP!'");
                    Console.WriteLine("An angry guard comes to the door. 'What the heck are you yelling about?!'");
                    Console.WriteLine("The guard opens the cell door, enters the room, punches you in the mouth, leaves the room, locks the door, and walks back to wherever he came from");
                    //player loses 1 life
                    Console.WriteLine($"Your health goes from from {State.currentPlayer.Health} to {State.currentPlayer.Health - 1}");
                    var updatesLife = new Dictionary<string, object>
                    {
                        {"Health", State.currentPlayer.Health - 1}
                    };
                    //this also gets the loggedinplayer again and sets loggedinplayer after being updated
                    playerService.UpdateFields(updatesLife);
                    if (State.currentPlayer.Health == 0)
                    {
                        Console.WriteLine("Oh no! You are out of health. You are dead.");
                        stillInRoom = false;
                    };

                    break;
                case "3":
                case "Three":
                case "three":
                    //if the player has the key
                    if (State.playerItems.DungeonKey == 1)
                    {
                        Console.WriteLine("You go up to the heavy gate, and think, 'maybe this key will unlock the door!'");
                        Console.WriteLine("You put the key into the gate, and it opens!");
                        Console.WriteLine("You leave the room, and enter the hallway...");
                        //they escape, while loop is now false
                        var updatesRoom = new Dictionary<string, object>
                        {
                            {"CurrentRoom", 2},
                        };
                        playerService.UpdateFields(updatesRoom);
                        stillInRoom = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You go up to the heavy gate, and try to open the door.");
                        Console.WriteLine("The door requires a key");
                        break;
                    }
                default:
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                    break;

            }

            //if the players health is 0, then it says game over, and sets current room to 0, and health back to 5
            //make it that current room is now 2
        }
        Console.WriteLine("Congratulations. You have escaped the dungeon");
    }

    public void PlayRoomTwo()
    {
        bool stillInRoom = true;
        Console.WriteLine()
    }
}