namespace fc24players.Models;

public class PlayerPlaystyle
{
    public Player Player { get; set; }
    public int PlayerId { get; set; }
    
    public Playstyle Playstyle { get; set; }
    public int PlaystyleId { get; set; }
}