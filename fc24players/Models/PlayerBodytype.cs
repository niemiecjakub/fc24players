namespace fc24players.Models;

public class PlayerBodytype
{
    public Player Player { get; set; }
    public int PlayerId { get; set; }
    
    public Bodytype Bodytype { get; set; }
    public int BodytypeId { get; set; }
}