

namespace Project1App.Entities;

public class Login
{

    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LoginId { get; set; }


    public string UserName { get; set; }

    public string Password { get; set; }

    public Player Player { get; set; } = null!;



    public override string ToString()
    {
        return $"{LoginId} {UserName} {Password}";
    }
}