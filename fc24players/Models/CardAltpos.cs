using Microsoft.EntityFrameworkCore;

namespace fc24players.Models;

[Keyless]
public class CardAltpos
{
    public Card Card { get; set; }
    public int CardId { get; set; }
    public Position Altpos { get; set; }
    public int AltposId { get; set; }
}