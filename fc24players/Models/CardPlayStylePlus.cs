namespace fc24players.Models;

public class CardPlayStylePlus
{
    public int Id { get; set; }
    public Card Card { get; set; }
    public int CardId { get; set; }
    
    public Playstyle Playstyle { get; set; }
    public int PlaystyleId { get; set; }
}