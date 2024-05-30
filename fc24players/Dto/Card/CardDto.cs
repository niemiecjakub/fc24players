using fc24players.Dtos;

namespace fc24players.Dto.Card;

public class CardDto 
{
    public int Id { get; set; }
    public PlayerDto Player { get; set; }
    public string? League { get; set; }
    public string? Version { get; set; }
    public string? Club { get; set; }
    public string Position  { get; set; }
    public int? OverallRating  { get; set; }
    public int? Price { get; set; }
    public string Link { get; set; }
    public int? PAC { get; set; }
    public int? SHO { get; set; }
    public int? PAS { get; set; }
    public int? DRI { get; set; }
    public int? DEF { get; set; }
    public int? PHY { get; set; }
    public int? DIV { get; set; }
    public int? HAN { get; set; }
    public int? KIC { get; set; }
    public int? REF { get; set; }
    public int? SPD { get; set; }
    public int? POS { get; set; }
}