namespace fc24players.Dto.Nationality;

public class NationalityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<string> Players { get; set; }
}