using fc24players.Dto.IndividualStats;

namespace fc24players.Dto.Card;

public class CardDetailedDto : CardDto
{
    public int? Age  { get; set; }
    public PacStatsDto? PacStats { get; set; }
    public ShoStatsDto? ShoStats { get; set; }
    public PasStatsDto? PasStats { get; set; }
    public DriStatsDto? DriStats { get; set; }
    public DefStatsDto? DefStats { get; set; }
    public PhyStatsDto? PhyStats { get; set; }
    public GkStatsDto? GkStats { get; set; }
    public List<string> Bodytype { get; set; }
    public List<string> AltPos { get; set; }
    public List<string> Playstyle { get; set; }
    public List<string> PlaystylePlus { get; set; }
}
