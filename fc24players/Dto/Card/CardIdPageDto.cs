namespace fc24players.Dto.Card;

public class CardIdPageDto
{
    public IEnumerable<int> Data { get; set; } 
    public int? NextId { get; set; } 
    public int? PreviousId { get; set; } 
    public bool IsFirstPage { get; set; } 
}