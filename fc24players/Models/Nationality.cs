namespace fc24players.Models;

public class Nationality
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Player> Players { get; set; }
    public ICollection<Card> Cards { get; set; }
}