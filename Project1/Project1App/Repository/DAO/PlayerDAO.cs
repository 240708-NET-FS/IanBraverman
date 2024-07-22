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
        _context.Players.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Player item)
    {
        _context.Players.Remove(item);
        _context.SaveChanges();
    }

    public ICollection<Player> GetAll()
    {
        List<Player> players = _context.Players.ToList();

        return players;
    }

    public Player GetByID(int ID)
    {
        Player player = _context.Players.FirstOrDefault(p => p.PlayerId == ID);

        return player;

    }

    public void Update(Player newItem)
    {
        Player originalPlayer = _context.Players.FirstOrDefault(p => p.PlayerId == newItem.PlayerId);

        if (originalPlayer != null)
        {
            originalPlayer.FirstName = newItem.FirstName;
            originalPlayer.LastName = newItem.LastName;
            originalPlayer.CurrentRoom = newItem.CurrentRoom;
            originalPlayer.Health = newItem.Health;

        }
    }

    public void UpdateField(int PlayerID, Dictionary<string, object> updates)
    //will take the playerID, and search for it in the database, then assign originalPlayer to that, then only make updates
    // to ones that had changes made
    {
        Player originalPlayer = _context.Players.FirstOrDefault(p => p.PlayerId == PlayerID);

        if (originalPlayer != null)
        {
            foreach (var update in updates)
            {
                var property = originalPlayer.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalPlayer, update.Value);
                }

            }
        }
        _context.SaveChanges();

        /* example of how to make a change

        var dao = new PlayerDAO(context);

        updates = new Dictionary<string, object>
        {
            { "FirstName", newFirstNameValue },
            { "Health", newHealthValue }
        }       ;

        dao.Update(playerItemsID, updates);
    */
    }
}
