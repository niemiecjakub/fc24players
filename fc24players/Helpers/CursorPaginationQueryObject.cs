namespace fc24players.Helpers;

public class CursorPaginationQueryObject
{
    public int PageSize { get; set; } = 20;
    public int? Cursor { get; set; }
    public bool? IsNextPage { get; set; }
}