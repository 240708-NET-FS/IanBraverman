namespace Project1App.Entities;



public class PlayerItems
{
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlayerItemsId { get; set; }

    public int Sword { get; set; }

    public int Shield { get; set; }

    public int Armor { get; set; }

    public int Helmet { get; set; }

    public int DungeonKey { get; set; }

    public int PlayerId { get; set; }

    public Player Player { get; set; }

    public override string ToString()
    {
        return $"{PlayerItemsId} {Sword} {Shield} {Armor} {Helmet} {DungeonKey} {Player}";
    }
}