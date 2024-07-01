namespace fc24players.Dto.Club;

public class ClubDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Manager { get; set; }
    public string? AltName { get; set; }
    public string? Code { get; set; }
    public string? Stadium { get; set; }
    public string? Location { get; set; }
    public int? YearFounded { get; set; }
}