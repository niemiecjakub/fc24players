namespace fc24players.Models;

public class Playstyle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<CardPlaystyle> Cards { get; set; }
}