using Microsoft.EntityFrameworkCore;
using Project1App.Entities;

namespace Project1App.DAO;

public class PlayerItemsDAO : IDAO<PlayerItems>
{

    private ApplicationDbContext _context;

    public PlayerItemsDAO(ApplicationDbContext context)
    {
        _context = context;
    }


    public void Create(PlayerItems item)
    {
        _context.PlayerItems.Add(item);
        _context.SaveChanges();
    }

    public void Delete(PlayerItems item)
    {
        _context.PlayerItems.Remove(item);
        _context.SaveChanges();
    }

    public ICollection<PlayerItems> GetAll()
    {
        List<PlayerItems> playerItems = _context.PlayerItems.Include(p => p.Player).ToList();
        return playerItems;
    }

    public PlayerItems GetByID(int ID)
    {
        PlayerItems playerItems = _context.PlayerItems.Include(p => p.Player).FirstOrDefault(pi => pi.PlayerId == ID);
        return playerItems;
    }

    public void Update(PlayerItems item) // Implementing the expected method
    {
        _context.PlayerItems.Update(item);
        _context.SaveChanges();
    }

    public void UpdateFields(int PlayerID, Dictionary<string, object> updates)
    //so this update takes the playerItemsID to search for in database and assign, then a dictionary that includes string and an object as key value pair of updates
    {
        PlayerItems originalPlayerItems = _context.PlayerItems.FirstOrDefault(pi => pi.PlayerId == PlayerID);

        if (originalPlayerItems != null)
        //if originalPlayerItems didnt come back empty
        {
            //for every update
            foreach (var update in updates)
            {
                var property = originalPlayerItems.GetType().GetProperty(update.Key);
                if (property != null && property.CanWrite)
                {
                    property.SetValue(originalPlayerItems, update.Value);
                }
            }
        }
        _context.SaveChanges();


    }

    /* example of how to make a change

var dao = new PlayerItemsDAO(context);

updates = new Dictionary<string, object>
{
    { "Sword", newSwordValue },
    { "Helmet", newHelmetValue }
};

dao.Update(playerID, updates);
    */
}

