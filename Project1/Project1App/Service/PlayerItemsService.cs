using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;
using Project1App.Utility.Exceptions;

namespace Project1App.Service;

public class PlayerItemsService : IService<PlayerItems>
{

    private readonly PlayerItemsDAO _playerItemsDAO;

    public PlayerItemsService(PlayerItemsDAO playerItemsDAO)
    {
        _playerItemsDAO = playerItemsDAO;
    }

    public void UpdateFields(Dictionary<string, object> updates)
    {
        _playerItemsDAO.UpdateFields(State.currentPlayer.PlayerId, updates);
        var currentPlayerItems = _playerItemsDAO.GetByID(Utility.State.currentPlayer.PlayerId);
        State.playerItems = currentPlayerItems;
        //NEED TO USE GET BY ID PLAYER ITEMS AND SET CURRENT PLAYER TO UPDATED AGAIN
    }

    public void RegisterNewPlayerItems(int playerId, Player PlayerObj)
    {
        PlayerItems playerItems = new PlayerItems { Sword = 0, Shield = 0, Armor = 0, Helmet = 0, DungeonKey = 0, PlayerId = playerId, Player = PlayerObj };
        _playerItemsDAO.Create(playerItems);

        State.playerItems = playerItems;

    }


    public void Create(PlayerItems item)
    {
        throw new NotImplementedException();
    }

    public void Delete(PlayerItems item)
    {
        throw new NotImplementedException();
    }

    public ICollection<PlayerItems> GetAll()
    {
        throw new NotImplementedException();
    }

    public PlayerItems GetByID(int Id)
    {
        var currentPlayerItems = _playerItemsDAO.GetByID(Utility.State.currentPlayer.PlayerId);
        return currentPlayerItems;
    }

    public void Update(PlayerItems item)
    {
        throw new NotImplementedException();
    }
}
