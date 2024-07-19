using Project1App.DAO;
using Project1App.Service;

namespace Project1App.Controller;

public class PlayerController
{
    private PlayerService playerService;

    public PlayerController(PlayerService service)
    {
        playerService = service;
    }
}