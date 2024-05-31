using Microsoft.EntityFrameworkCore;

namespace fc24players.Models;

[Keyless]
public class CardPlaystyle
{
    public Card Card { get; set; }
    public int CardId { get; set; }
    public Playstyle Playstyle { get; set; }
    public int PlaystyleId { get; set; }
}