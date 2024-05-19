using fc24players.Dto.Nationality;
using fc24players.Models;

namespace fc24players.Mapper;

public static class NationalityMapper
{
    public static NationalityDto ToNationalityDto(this Nationality nationality)
    {
        return new NationalityDto()
        {
            Id = nationality.Id,
            Name = nationality.Name,
            Players = nationality.Players.Select(p => p.Name).ToList()
        };
    }
}