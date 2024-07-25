using System.Net.NetworkInformation;
using Project1App.Entities;
using Project1App.DAO;
using Project1App.Utility;
using Project1App.Utility.Exceptions;

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

    public Player GetByLoginID()
    {
        var loggedInPlayer = _playerDAO.GetByLoginID(Utility.State.currentLogin.LoginId);
        return loggedInPlayer;
    }

    public void Update(Player item)
    {
        throw new NotImplementedException();
    }

    public void UpdateFields(Dictionary<string, object> updates)
    {
        _playerDAO.UpdateFields(State.currentPlayer.PlayerId, updates);
        var loggedInPlayer = _playerDAO.GetByLoginID(Utility.State.currentLogin.LoginId);
        State.currentPlayer = loggedInPlayer;
    }

    public void RegisterNewPlayer(string FirstName, string LastName, int LoginId, Login LoginObj)
    {
        if (FirstName.Length == 0 || LastName.Length == 0)
        {
            throw new LoginException("Invalid Register Input");
        }

        Player player = new Player { FirstName = FirstName, LastName = LastName, CurrentRoom = 0, Health = 5, LoginId = LoginId, Login = LoginObj };

        _playerDAO.Create(player);

        State.currentPlayer = player;

    }



}
