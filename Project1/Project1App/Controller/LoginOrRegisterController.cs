using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;
using Project1App.Utility.Exceptions;
using Project1App.Controller;

namespace Project1App.Controller;

public class LoginOrRegisterController
{
    public static bool LoginOrRegister()
    {
        while (true)
        {
            Console.WriteLine("Would you like to login or register?");
            Console.WriteLine("Please enter 'login' or 'register' below(or 'l' for login, 'r' for register): ");

            string loginOrRegisterAnswer = Console.ReadLine();

            switch (loginOrRegisterAnswer)
            {
                case "L":
                case "l":
                case "Login":
                case "login":
                    return true;
                case "R":
                case "r":
                case "Register":
                case "register":
                    return false;
                default:
                    Console.WriteLine("Invalid input. Please enter 'login' or 'register' (or 'l' for login, 'r' for register).");
                    break;
            }
        }
    }
}