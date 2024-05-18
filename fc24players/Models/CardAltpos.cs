namespace fc24players.Models;

public class CardAltpos
{
    public int Id { get; set; }
    public Card Card { get; set; }
    public int CardrId { get; set; }
    
    public Position Position { get; set; }
    public int PositionId { get; set; }
}