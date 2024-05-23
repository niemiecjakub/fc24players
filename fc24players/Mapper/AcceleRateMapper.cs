using fc24players.Dto.AcceleRate;
using fc24players.Models;

namespace fc24players.Mapper;

public static class AcceleRateMapper
{
    public static AcceleRateDto ToAccelerateDto(this AcceleRate acceleRate, ICollection<Card> cards)
    {
        return new AcceleRateDto()
        {
            Id = acceleRate.Id,
            Name = acceleRate.Name,
            Cards = cards.Select(c => c.ToCardDto()).ToList(),
        };
    }
}