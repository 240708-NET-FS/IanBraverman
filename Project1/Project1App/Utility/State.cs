using Project1App.Entities;

namespace Project1App.Utility;

public static class State
{
    public static bool isActive { get; set; }

    public static Login currentLogin { get; set; }

    public static Player currentPlayer { get; set; }
}