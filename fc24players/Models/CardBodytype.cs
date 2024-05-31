using Microsoft.EntityFrameworkCore;

namespace fc24players.Models;

[Keyless]
public class CardBodytype
{
    public Card Card { get; set; }
    public int CardId { get; set; }
    public Bodytype Bodytype { get; set; }
    public int BodytypeId { get; set; }
}