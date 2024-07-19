using Microsoft.EntityFrameworkCore;
using Project1App.Entities;

namespace Project1App.DAO;

public class LoginDAO : IDAO<Login>
{

    private ApplicationDbContext _context;

    public LoginDAO(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Login item)
    {
        _context.Logins.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Login item)
    {
        _context.Logins.Remove(item);
        _context.SaveChanges();
    }

    public ICollection<Login> GetAll()
    {
        List<Login> logins = _context.Logins.Include(l => l.Player).ToList();
        return logins;
    }

    public Login GetByID(int ID)
    {
        Login login = _context.Logins.Include(l => l.Player).FirstOrDefault(l => l.LoginID == ID);

        return login;
    }

    public void Update(Login newItem)
    {
        Login originalLogin = _context.Logins.Include(l => l.Player).FirstOrDefault(l => l.LoginID == newItem.LoginID);
        if (originalLogin != null)
        {
            originalLogin.UserName = newItem.UserName;
            originalLogin.Password = newItem.Password;
            _context.Logins.Update(originalLogin);
            _context.SaveChanges();
        }
    }

    public Login GetLoginByUsernameAndPassword(string username, string password)
    {
        Login login = _context.Logins.Include(l => l.Player).FirstOrDefault(l => l.UserName == username && l.Password == password);

        return login;
    }
}
