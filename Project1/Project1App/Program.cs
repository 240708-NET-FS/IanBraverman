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
            LoginController loginController = new LoginController(loginService);

            State.isActive = true;

            while (State.isActive)
            {
                loginController.Login();
            }

        }
    }
}