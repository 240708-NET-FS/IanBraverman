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
