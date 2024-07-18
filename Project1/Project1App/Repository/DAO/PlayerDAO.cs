using Project1App.Entities;

namespace Project1App.DAO;

public class PlayerDAO : IDAO<Player>
{

    private ApplicationDbContext _context;

    public PlayerDAO(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Player item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Player item)
    {
        throw new NotImplementedException();
    }

    public ICollection<Player> GetAll()
    {
        throw new NotImplementedException();
    }

    public Player GetByID(int ID)
    {
        throw new NotImplementedException();
    }

    public void Update(Player newItem)
    {
        throw new NotImplementedException();
    }
}
