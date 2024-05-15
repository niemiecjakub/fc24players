namespace fc24players.Models;

public class PlayerAltpos
{
    public int Id { get; set; }
    public Player Player { get; set; }
    public int PlayerId { get; set; }
    
    public Position Position { get; set; }
    public int PositionId { get; set; }
}