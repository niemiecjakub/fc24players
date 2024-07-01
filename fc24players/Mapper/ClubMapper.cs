using fc24players.Dto.Club;
using fc24players.Models;

namespace fc24players.Mapper;

public static class ClubMapper
{
    public static ClubDto ToClubDto(this Club club)
    {
        return new ClubDto()
        {
            Id = club.Id,
            Name = club.Name,
            AltName = club.AltName,
            Code = club.Code,
            Stadium = club.Stadium,
            Location = club.Location,
            YearFounded = club.YearFounded,
            Manager = club.Manager?.Name,
        };
    }
}