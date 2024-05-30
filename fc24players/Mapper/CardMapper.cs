using fc24players.Dto.Card;
using fc24players.Dto.IndividualStats;
using fc24players.Models;

namespace fc24players.Mapper;

public static class CardMapper
{
    public static CardDto ToCardDto(this Card card)
    {
        return new CardDto()
        {
            Id = card.Id,
            Player = card.Player.ToPlayerDto(),
            League = card.League.Name,
            Version = card.Version?.Name,
            Club = card.Club?.Name,
            Position = card.Position?.Name,
            OverallRating = card.OverallRating,
            Price = card.Price,
            Link = card.Link,
            SHO = card.SHO,
            DEF = card.DEF,
            DRI = card.DRI,
            PAC = card.PAC,
            PAS = card.PAS,
            PHY = card.PHY,
            DIV = card.DIV,
            HAN = card.HAN,
            KIC = card.KIC,
            POS = card.POS,
            REF = card.REF,
            SPD = card.SPD,
        };
    }
    
    public static CardDetailedDto ToCardDetailedDto(this Card card)
    {
        return new CardDetailedDto()
        {
            Id = card.Id,
            Player = card.Player.ToPlayerDto(),
            Version = card.Version.Name,
            Club = card.Club.Name,
            League = card.League.Name,
            Position = card.Position.Name,
            Age = card.Age,
            OverallRating = card.OverallRating,
            Price = card.Price,
            Link = card.Link,
            SHO = card.SHO,
            ShoStats = new ShoStatsDto()
            {
                Finishing = card.Finishing,
                LongShots = card.LongShots,
                ShotPower = card.ShotPower,
                Positioning = card.Positioning,
                Penalties = card.Penalties,
                Volleys = card.Volleys
            },
            DEF = card.DEF,
            DefStats = new DefStatsDto()
            {
                Interceptions = card.Interceptions,
                DefAwareness = card.DefAwareness,
                HeadingAcc = card.HeadingAcc,
                SlideTackle = card.SlideTackle,
                StandTackle = card.StandTackle
            },
            DRI = card.DRI,
            DriStats = new DriStatsDto()
            {
                Agility = card.Agility,
                Composure = card.Composure,
                Dribbling = card.Dribbling,
                BallControl = card.BallControl,
                Reactions = card.Reactions,
                Balance = card.Balance
            },
            PAC = card.PAC,
            PacStats = new PacStatsDto()
            {
                Acceleration = card.Acceleration,
                SprintSpeed = card.SprintSpeed
            },
            PAS = card.PAS,
            PasStats = new PasStatsDto()
            {
                ShortPass = card.ShortPass,
                LongPass = card.LongPass,
                FkAcc = card.FKAcc,
                Crossing = card.Crossing,
                Curve = card.Curve,
                Vision = card.Vision
            },
            PHY = card.PHY,
            PhyStats = new PhyStatsDto()
            {
                Aggression = card.Agression,
                Strength = card.Strength,
                Jumping = card.Jumping,
                Stamina = card.Stamina
            },
            DIV = card.DIV,
            HAN = card.HAN,
            KIC = card.KIC,
            POS = card.POS,
            REF = card.REF,
            SPD = card.SPD,
            GkStats = new GkStatsDto()
            {
                GkDiving = card.GKDiving,
                GkHandling = card.GKHandling,
                GkKicking = card.GKKicking,
                GkPos = card.GKPos,
                GkReflexes = card.GKReflexes
            }
            
        };
    }

}