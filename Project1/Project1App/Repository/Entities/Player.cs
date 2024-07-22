namespace Project1App.Entities;


public class Player
{
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlayerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int CurrentRoom { get; set; }

    public int Health { get; set; }

    public int LoginId { get; set; }
    public Login Login { get; set; }

    public PlayerItems PlayerItems { get; set; }

    public override string ToString()
    {
        return $"{PlayerId} {FirstName} {LastName} {CurrentRoom} {Health} {Login} {PlayerItems}";
    }
}