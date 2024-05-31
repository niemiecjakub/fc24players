namespace fc24players.Models;

public class CardBodytype
{
    public int Id { get; set; }
    public Card Card { get; set; }
    public int CardId { get; set; }
    
    public Bodytype Bodytype { get; set; }
    public int BodytypeId { get; set; }
}