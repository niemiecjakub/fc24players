namespace fc24players.Models;

public class Playstyle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<CardPlaystyle> PlaystyleCards { get; set; } = new List<CardPlaystyle>();
    public ICollection<CardPlayStylePlus> PlaystylePlusCards { get; set; } = new List<CardPlayStylePlus>();
}