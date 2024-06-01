using fc24players.Dto.IndividualStats;

namespace fc24players.Dto.Card;

public class CardDetailedDto : CardDto
{
    public int? Age  { get; set; }
    public int? SkillMoves { get; set; }
    public  int? WeakFoot{ get; set; }
    public  int? Height{ get; set; }
    public string? AttWr { get; set; }
    public string? DefWr{ get; set; }
    public  string? Foot{ get; set; }
    public string? AcceleRate { get; set; }
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
