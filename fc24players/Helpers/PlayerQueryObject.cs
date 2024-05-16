using fc24players.Models;

namespace fc24players.Helpers;

public class PlayerQueryObject
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
    public string? Nationality { get; set; }
}