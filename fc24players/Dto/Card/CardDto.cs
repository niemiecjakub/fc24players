using fc24players.Dtos;

namespace fc24players.Dto.Card;

public class CardDto
{
    public int Id { get; set; }
    public PlayerDto Player { get; set; }
    public string Version { get; set; }
    public string? Club { get; set; }
    public string Position  { get; set; }
    public int? Age  { get; set; }
    public int? OverallRating  { get; set; }
    public int? Price { get; set; }
    public string Link { get; set; }
}