using System.Reflection.Metadata;
using Project1App.Controller;
using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;


namespace Project1App;

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new ApplicationDbContext())
        {
            PlayerDAO playerDAO = new PlayerDAO(context);
            LoginDAO loginDAO = new LoginDAO(context);
            PlayerItemsDAO playerItemsDAO = new PlayerItemsDAO(context);

            PlayerService playerService = new PlayerService(playerDAO);
            LoginService loginService = new LoginService(loginDAO);
            PlayerItemsService playerItemsService = new PlayerItemsService(playerItemsDAO);

            PlayerController playerController = new PlayerController(playerService, playerItemsService);
            LoginController loginController = new LoginController(loginService, playerService);
            LoginOrRegisterController loginOrRegisterController = new LoginOrRegisterController();
            PlayGameController playGameController = new PlayGameController(playerItemsService, playerService);

            State.isActive = true;

            while (State.isActive)
            {
                if (State.currentLogin == null)
                {
                    bool loginOrRegister = LoginOrRegisterController.LoginOrRegister();
                    if (loginOrRegister == true)
                    {
                        loginController.Login();

                        context.SaveChanges();
                    }
                    else if (loginOrRegister == false)
                    {
                        loginController.Register();
                        playerController.NewPlayer();
                        playerItemsService.RegisterNewPlayerItems(State.currentPlayer.PlayerId, State.currentPlayer);
                        context.SaveChanges();
                    }
                }
                bool continueOrNew = playerController.NewGameOrContinue();
                if (continueOrNew == true)
                {
                    bool playingGame = true;
                    Console.WriteLine("Starting a new game...");
                    while (playingGame)
                    {
                        Console.WriteLine("current room for player " + State.currentPlayer.CurrentRoom);
                        //do you want to play or no
                        Console.WriteLine("Do you want to quit? Please type Yes or No");

                        string inputContinueOrQuit = Console.ReadLine();

                        switch (inputContinueOrQuit)
                        {
                            case "y":
                            case "Y":
                            case "Yes":
                            case "yes":
                                State.isActive = false;
                                playingGame = false;
                                break;
                            case "N":
                            case "n":
                            case "No":
                            case "no":
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }

                        if (State.currentPlayer.CurrentRoom == 0)
                        {
                            var updatesRoom = new Dictionary<string, object>
                                {
                                    {"CurrentRoom", 1},
                                };
                            playerService.UpdateFields(updatesRoom);

                        }
                        else if (State.currentPlayer.CurrentRoom == 1)
                        {
                            Console.WriteLine("Room One Start...");
                            playGameController.PlayRoomOne();
                        }
                        else if (State.currentPlayer.CurrentRoom == 2)
                        {
                            Console.WriteLine("Room Two Start...");
                            playGameController.PlayRoomTwo();
                        }
                        else
                        {
                            Console.WriteLine("You finished the game! Congrats!");
                            playingGame = false;
                        }
                    }
                    State.isActive = false;
                }
                else if (continueOrNew == false)
                {
                    bool playingGame = true;
                    Console.WriteLine("Continuing prior game...");
                    while (playingGame)
                    {
                        //if you are in room 0, puts you to one to start game

                        //do you want to play or no
                        Console.WriteLine("Do you want to quit? Please type Y or N");

                        string inputContinueOrQuit = Console.ReadLine();

                        switch (inputContinueOrQuit)
                        {
                            case "y":
                            case "Y":
                            case "Yes":
                            case "yes":
                                State.isActive = false;
                                playingGame = false;
                                break;
                            case "N":
                            case "n":
                            case "No":
                            case "no":
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }

                        if (State.currentPlayer.CurrentRoom == 0)
                        {
                            var updatesRoom = new Dictionary<string, object>
                                {
                                    {"CurrentRoom", 1},
                                };
                            playerService.UpdateFields(updatesRoom);

                        }
                        //if you are in room 1, starts room 1 game
                        else if (State.currentPlayer.CurrentRoom == 1)
                        {
                            Console.WriteLine("Room One Start...");
                            playGameController.PlayRoomOne();
                        }
                        else if (State.currentPlayer.CurrentRoom == 2)
                        {
                            Console.WriteLine("Room Two Start...");
                            playGameController.PlayRoomTwo();
                        }
                        else
                        {
                            Console.WriteLine("You finished the game! Congrats!");
                            playingGame = false;
                        }
                    }
                }
            }

        }

    }
}