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

    public Login GetByID(int ID)
    {
        throw new NotImplementedException();
    }

    public void Update(Login newItem)
    {
        throw new NotImplementedException();
    }
}
