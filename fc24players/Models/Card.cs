namespace fc24players.Models;

public class Card
{
    public int Id { get; set; }
    public Player Player { get; set; }
    public Nationality Nationality { get; set; }
    public League League { get; set; }
    public Club Club { get; set; }
    public Version Version { get; set; }
    public Position Position { get; set; }
    public PlayerAltpos PlayerAltpos { get; set; }
    public AcceleRate AcceleRate { get; set; }
    public PlayerPlaystyle PlayerPlaystyle { get; set; }
    public PlayerBodytype PlayerBodytype { get; set; }
}