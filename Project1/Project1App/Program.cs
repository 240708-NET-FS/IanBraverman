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

            PlayerService playerService = new PlayerService(playerDAO);
            LoginService loginService = new LoginService(loginDAO);

            PlayerController playerController = new PlayerController(playerService);
            LoginController loginController = new LoginController(loginService, playerService);

            State.isActive = true;

            while (State.isActive)
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
                    context.SaveChanges();
                }
            }

        }
        //this is testing the new player creation

        // var context = new ApplicationDbContext();
        // var player = new Player
        // {

        //     FirstName = "Ian",
        //     LastName = "Braverman",
        //     PlayerId = 2,
        //     LoginId = 1,

        // };
        // // var login = new Login
        // // {

        // //     UserName = "testuser",
        // //     Password = "password123",


        // // };
        // context.Players.Add(player);
        // context.SaveChanges();


        // context.Logins.Add(login);
        // context.SaveChanges();

        // Console.WriteLine($"New LoginID: {login.LoginId}");
    }
}