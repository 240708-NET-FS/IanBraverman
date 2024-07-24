namespace Project1App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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