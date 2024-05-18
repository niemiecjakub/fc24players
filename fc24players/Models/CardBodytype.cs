namespace fc24players.Models;

public class CardBodytype
{
    public int Id { get; set; }
    public Card Card { get; set; }
    public int CardrId { get; set; }
    
    public Bodytype Bodytype { get; set; }
    public int BodytypeId { get; set; }
}