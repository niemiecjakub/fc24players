namespace fc24players.Models;

public class Nationality
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Player> Players { get; set; }
    public List<Card> Cards { get; set; }
}