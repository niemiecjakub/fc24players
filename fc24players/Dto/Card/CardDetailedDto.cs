using fc24players.Dto.IndividualStats;

namespace fc24players.Dto.Card;

public class CardDetailedDto : CardDto
{
    public int? PAC { get; set; }
    public PacStatsDto? PacStats { get; set; }
    public int? SHO { get; set; }
    public ShoStatsDto? ShoStats { get; set; }
    public int? PAS { get; set; }
    public PasStatsDto? PasStats { get; set; }
    public int? DRI { get; set; }
    public DriStatsDto? DriStats { get; set; }
    public int? DEF { get; set; }
    public DefStatsDto? DefStats { get; set; }
    public int? PHY { get; set; }
    public PhyStatsDto? PhyStats { get; set; }
}
