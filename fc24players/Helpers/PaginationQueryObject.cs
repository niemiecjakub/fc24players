using fc24players.Models;

namespace fc24players.Helpers;

public class PaginationQueryObject
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}