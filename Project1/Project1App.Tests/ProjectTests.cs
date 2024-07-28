using Project1App;
using Project1App.Controller;
using Project1App.DAO;
using Project1App.Entities;
using Project1App.Service;
using Project1App.Utility;
namespace Project1AppTesting;

public class Project1AppTests
{
    //this is testing the new player creation

    // public void GetPlayer()
    // {
    //     var context = new ApplicationDbContext();

    //     var player = new Player
    //     {

    //         FirstName = "Ian",
    //         LastName = "Braverman",
    //         PlayerId = 2,
    //         LoginId = 1,
    //     };
    //     var result = context.Players.Add(player);
    //     var resultPlayerID = result.PlayerId
    //     context.SaveChanges();

    //     Assert.Equal(1, result);
    // }
    [Fact]

    public void GetLogin()
    {
        var context = new ApplicationDbContext();

        Login login = context.Logins.FirstOrDefault(l => l.LoginId == 1);

        int loginId = login.LoginId;

        Assert.Equal(1, loginId);
    }
    [Fact]
    public void GetPlayer()
    {
        var context = new ApplicationDbContext();
        Player player = context.Players.FirstOrDefault(p => p.PlayerId == 1);

        int playerId = player.PlayerId;

        Assert.Equal(1, playerId);
    }
}