namespace fc24players.Models;

public class Manager
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Nationality Nationality { get; set; }
    public Club Club { get; set; }
}