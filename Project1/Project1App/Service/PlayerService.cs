using System.Net.NetworkInformation;
using Project1App.Entities;
using Project1App.DAO;

namespace Project1App.Service;

public class PlayerService : IService<Player>
{
    private readonly PlayerDAO _playerDAO;

    public PlayerService(PlayerDAO playerDAO)
    {
        _playerDAO = playerDAO;
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

    public Player GetByID(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(Player item)
    {
        throw new NotImplementedException();
    }
}
