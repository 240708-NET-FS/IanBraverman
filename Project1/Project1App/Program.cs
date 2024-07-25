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
                        else
                        {
                            Console.WriteLine("You finished the game!");
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
                            playingGame = false;
                        }
                        else
                        {
                            Console.WriteLine("You finished the game!");
                            playingGame = false;
                        }
                    }
                }
            }

        }

    }
}