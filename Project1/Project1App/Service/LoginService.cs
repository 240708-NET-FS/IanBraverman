using Project1App.DAO;
using Project1App.Entities;
using Project1App.Utility.Exceptions;
using Project1App.Utility;

namespace Project1App.Service;

public class LoginService : IService<Login>
{

    private readonly LoginDAO _loginDAO;

    public LoginService(LoginDAO loginDAO)
    {
        _loginDAO = loginDAO;
    }



    public Login Login(string username, string password)
    {
        if (username.Length == 0 || password.Length == 0)
        {
            throw new LoginException("Invalid Login Input");
        }
        Login login = _loginDAO.GetLoginByUsernameAndPassword(username, password);

        if (login != null)
        {
            State.currentLogin = login;

            return login;
        }
        throw new LoginException("Invalid Login, Please Try Again");
    }

    public void Register(string username, string password)
    {
        if (username.Length == 0 || password.Length == 0)
        {
            throw new LoginException("Invalid Register Input");
        }



        Login login = new Login { UserName = username, Password = password };


        // //this checks to see if username already exists in the system
        Login loginById = _loginDAO.GetLoginByUsernameAndPassword(username, password);

        //need to have the ? because if loginbyID comes back null, then gives an error because cant do
        //.username on a null
        if (loginById?.UserName == username)
        {
            throw new LoginException("Username Already Exists. Please log in or use a different username");
        }

        _loginDAO.Register(login);

        loginById = _loginDAO.GetLoginByUsernameAndPassword(username, password);

        State.currentLogin = login;
    }

    public void Create(Login item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Login item)
    {
        throw new NotImplementedException();
    }

    public ICollection<Login> GetAll()
    {
        throw new NotImplementedException();
    }

    public Login GetByID(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(Login item)
    {
        throw new NotImplementedException();
    }
}
