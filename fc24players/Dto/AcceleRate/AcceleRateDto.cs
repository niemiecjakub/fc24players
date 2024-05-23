using fc24players.Dto.Card;

namespace fc24players.Dto.AcceleRate;

public class AcceleRateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<CardDto> Cards { get; set; }
}