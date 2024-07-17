using Microsoft.Identity.Client;

namespace Project1App.Entities;

public class Login
{
    public int LoginID { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }

    public Player Player { get; set; }

    public override string ToString()
    {
        return $"{LoginID} {UserName} {Password}";
    }
}