namespace fc24players.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Nationality Nationality { get; set; }
    public List<Card> Cards { get; set; }
}