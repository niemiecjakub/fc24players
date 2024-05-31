namespace fc24players.Models;

public class Position
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Card> Cards { get; set; } = new List<Card>();
    public ICollection<CardAltpos> CardAltpos { get; set; } = new List<CardAltpos>();
}