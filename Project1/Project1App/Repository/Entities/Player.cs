namespace Project1App.Entities;

public class Player
{
    public int PlayerID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int CurrentRoom { get; set; }

    public int Health { get; set; }

    public Login Login { get; set; }

    public PlayerItems PlayerItems { get; set; }

    public override string ToString()
    {
        return $"{PlayerID} {FirstName} {LastName} {CurrentRoom} {Health} {Login} {PlayerItems}";
    }
}