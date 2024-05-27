using fc24players.Models;

namespace fc24players.Helpers;

public class PaginationQueryObject
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}