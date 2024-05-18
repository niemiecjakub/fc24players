namespace fc24players.Models;

public class Bodytype
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<CardBodytype> Cards { get; set; }
}