namespace fc24players.Models;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Card> Cards { get; set; }
}