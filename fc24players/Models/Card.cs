namespace fc24players.Models;

public class Card
{
    public int Id { get; set; }
    public Player Player { get; set; }
    public Nationality Nationality { get; set; }
    public League League { get; set; }
    public Club? Club { get; set; }
    public Version Version { get; set; }
    public Position Position { get; set; }
    public AcceleRate? AcceleRate { get; set; }
    public  int? OverallRating{ get; set; }
    public string? DefWR{ get; set; }
    public string? AttWR { get; set; }
    public string? Link { get; set; }
    public  string? Foot{ get; set; }
    public  int? Height{ get; set; }
    public  int? Weight{ get; set; }
    public  int? WeakFoot{ get; set; }
    public  int? SkillMoves{ get; set; }
    public  int? Acceleration{ get; set; }
    public  int? Agression{ get; set; }
    public  int? Age{ get; set; }
    public  int? Agility{ get; set; }
    public  int? Balance{ get; set; }
    public  int? BallControl{ get; set; }
    public  int? Composure{ get; set; }
    public  int? Dribbling { get; set; }
    public  int? Finishing { get; set; }
    public  int? Jumping{ get; set; }
    public  int? LongShots{ get; set; }
    public  int? Penalties{ get; set; }
    public  int? Positioning{ get; set; }
    public  int? Reactions{ get; set; }
    public  int? ShotPower{ get; set; }
    public  int? SprintSpeed{ get; set; }
    public  int? Stamina{ get; set; }
    public  int? Strength{ get; set; }
    public  int? Volleys{ get; set; }
    public  int? SlideTackle{ get; set; }
    public  int? Price{ get; set; }
    public  int? Crossing{ get; set; }
    public  int? Curve{ get; set; }
    public  int? DEF{ get; set; }
    public  int? DRI{ get; set; }
    public  int? DefAwareness{ get; set; }
    public  int? FKAcc{ get; set; }
    public  int? HeadingAcc{ get; set; }
    public  int? Interceptions{ get; set; }
    public  int? LongPass{ get; set; }
    public  int? PAC{ get; set; }
    public  int? PAS{ get; set; }
    public  int? PHY{ get; set; }
    public  int? SHO{ get; set; }
    public  int? ShortPass{ get; set; }
    public  int? StandTackle{ get; set; }
    public  int? Vision{ get; set; }
    public  int? DIV{ get; set; }
    public  int? GKDiving{ get; set; }
    public  int? GKHandling{ get; set; }
    public  int? GKKicking{ get; set; }
    public  int? GKPos{ get; set; }
    public  int? GKReflexes{ get; set; }
    public  int? HAN{ get; set; }
    public  int? KIC{ get; set; }
    public  int? POS{ get; set; }
    public  int? REF{ get; set; }
    public  int? SPD{ get; set; }
    public  DateTime? Added{ get; set; }
    
    // public PlayerAltpos PlayerAltpos { get; set; }
    // public PlayerPlaystyle PlayerPlaystyle { get; set; }
    // public PlayerPlayStylePlus? PlayerPlayStylePlus
    // public PlayerBodytype? PlayerBodytype { get; set; }
}