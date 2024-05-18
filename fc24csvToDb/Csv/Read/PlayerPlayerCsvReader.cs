using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using fc24csvToDb.Helpers;
using fc24players.Models;
using Version = fc24players.Models.Version;

namespace fc24csvToDb.Csv;

public class PlayerPlayerCsvReader(string filePath) : IPlayerCsvReader
{
    public CsvReader CreateCsvReader()
    {
        var reader = new StreamReader(filePath);
        var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            MissingFieldFound = null
        });

        csvReader.Read();
        csvReader.ReadHeader();

        return csvReader;
    }

    public IEnumerable<AcceleRate> ReadAcceleRate()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var acceleRate = reader.GetField<string>("AcceleRATE");
                if (string.IsNullOrWhiteSpace(acceleRate))
                {
                    continue;
                }

                yield return new AcceleRate()
                {
                    Name = acceleRate.Trim()
                };
            }
        }
    }

    public IEnumerable<Playstyle> ReadPlaystyle()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var playStyle = reader.GetField<string>("PlayStyles").Split(",");
                var playStylePlus = reader.GetField<string>("PlayStyles+").Split(",");

                List<string> playStyleList = new List<string>(playStyle);
                playStyleList.AddRange(playStylePlus);

                string[] allPlaystyles = playStyleList.ToArray();
                foreach (var ps in allPlaystyles)
                {
                    if (string.IsNullOrWhiteSpace(ps))
                    {
                        continue;
                    }

                    yield return new Playstyle()
                    {
                        Name = ps.Trim()
                    };
                }
            }
        }
    }

    public IEnumerable<Version> ReadVersion()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var version = reader.GetField<string>("Version");
                if (string.IsNullOrWhiteSpace(version))
                {
                    continue;
                }

                yield return new Version()
                {
                    Name = version.Trim()
                };
            }
        }
    }

    public IEnumerable<List<Position>> ReadPosition()
    {
        //TODO: Fix
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var mainPosition = reader.GetField<string>("Position");
                var altPosition = reader.GetField<string>("Alt Pos.").Split(",");

                List<string> positionList = new List<string>(altPosition);
                positionList.Add(mainPosition);
                string[] allPositions = positionList.ToArray();
                
                List<Position> positions = new List<Position>();
                foreach (var position in allPositions)
                {
                    if (string.IsNullOrWhiteSpace(position) || position.Equals("None"))
                    {
                        continue;
                    }
                    positions.Add(new Position()
                    {
                        Name = position.Trim()
                    });
                }

                yield return positions;
            }
        }
    }

    public IEnumerable<List<Bodytype>> ReadBodytype()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var bodytype = reader.GetField<string>("Body Type");
                String[] bodytypes = bodytype.Split("&");
                
                List<Bodytype> bodytypeList = new List<Bodytype>();
                foreach (var body in bodytypes)
                {
                    if (string.IsNullOrWhiteSpace(body) || body.Equals("--"))
                    {
                        continue;
                    }
                    bodytypeList.Add(new Bodytype()
                    {
                        Name = body.Trim()
                    });
                }
                yield return bodytypeList;
            }
        }
    }

    public IEnumerable<Club> ReadClub()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var club = reader.GetField<string>("Club");
                if (string.IsNullOrWhiteSpace(club))
                {
                    continue;
                }

                yield return new Club()
                {
                    Name = club
                };
            }
        }
    }

    public IEnumerable<League> ReadLeague()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var league = reader.GetField<string>("League");
                if (string.IsNullOrWhiteSpace(league))
                {
                    continue;
                }

                yield return new League()
                {
                    Name = league
                };
            }
        }
    }

    public IEnumerable<Nationality> ReadNationality()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var nationality = reader.GetField<string>("Nationality");
                if (string.IsNullOrWhiteSpace(nationality))
                {
                    continue;
                }

                yield return new Nationality()
                {
                    Name = nationality
                };
            }
        }
    }

    public IEnumerable<Player> ReadPlayer()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var playerName = reader.GetField<string>("Name");
                var nationality = reader.GetField<string>("Nationality");
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    continue;
                }

                yield return new Player()
                {
                    Name = playerName,
                    Nationality = new Nationality()
                    {
                        Name = nationality
                    }
                };
            }
        }
    }

    public IEnumerable<Card> ReadCard()
    {
        using (var reader = CreateCsvReader())
        {
            while (reader.Read())
            {
                var id = reader.GetField<int>("ID");
                var playerName = reader.GetField<string>("Name");
                var nationality = reader.GetField<string>("Nationality");
                var club = reader.GetField<string>("Club");
                var version = reader.GetField<string>("Version");
                var position = reader.GetField<string>("Position");
                var acceleRate = reader.GetField<string>("AcceleRATE");
                var league = reader.GetField<string>("League");

                
                yield return new Card()
                    {
                        Id = id,
                        Player = new Player()
                        {
                            Name = playerName
                        },
                        Nationality = new Nationality()
                        {
                            Name = nationality.Trim()
                        },
                        Club = new Club()
                        {
                            Name = club.Trim()
                        },
                        Version = new Version()
                        {
                            Name = version.Trim()
                        },
                        Position = new Position()
                        {
                            Name = position.Trim()
                        },
                        AcceleRate = new AcceleRate()
                        {
                            Name = acceleRate.Trim()
                        },
                        League = new League()
                        {
                          Name  = league.Trim()
                        },
                        OverallRating = reader.GetField<int?>("Overall Rating"),
                        DefWR = reader.GetField<string?>("Def W/R"),
                        AttWR = reader.GetField<string?>("Att W/R"),
                        Link = reader.GetField<string?>("Futwiz Link"),
                        Foot = reader.GetField<string?>("Foot"),
                        Height = reader.GetField<string?>("Height").GetHeightInCm(),
                        Weight = reader.GetField<string?>("Weight").StripUnits(),
                        WeakFoot = reader.GetField<int?>("Weak Foot"),
                        
                        SkillMoves = reader.GetField<int?>("Skill Moves"),
                        Acceleration = reader.GetField<int?>("Acceleration"),
                        Agression = reader.GetField<int?>("Aggression"),
                        Age = reader.GetField<int?>("Age"),
                        Agility = reader.GetField<int?>("Agility"),
                        Balance = reader.GetField<int?>("Balance"),
                        BallControl = reader.GetField<int?>("Ball Control"),
                        Composure = reader.GetField<int?>("Composure"),
                        Dribbling = reader.GetField<int?>("Dribbling"),
                        Finishing = reader.GetField<int?>("Finishing"),
                        Jumping = reader.GetField<int?>("Jumping"),
                        LongShots = reader.GetField<int?>("Long Shots"),
                        Penalties = reader.GetField<int?>("Penalties"),
                        Positioning = reader.GetField<int?>("Positioning"),
                        Reactions = reader.GetField<int?>("Reactions"),
                        ShotPower = reader.GetField<int?>("Shot Power"),
                        SlideTackle = reader.GetField<int?>("Slide Tackle"),
                        SprintSpeed = reader.GetField<int>("Sprint Speed"),
                        Stamina = reader.GetField<int>("Stamina"),
                        Strength = reader.GetField<int>("Strength"),
                        Volleys = reader.GetField<int>("Volleys"),
                        Added = reader.GetField<DateTime?>("Added"),
                        Price = reader.GetField<int?>("Price"),
                        Crossing = reader.GetField<int?>("Crossing"),
                        Curve = reader.GetField<int?>("Curve"),
                        DEF = reader.GetField<int?>("DEF"),
                        DRI = reader.GetField<int?>("DRI"),
                        DefAwareness = reader.GetField<int?>("Def Awareness"),
                        FKAcc = reader.GetField<int?>("FK Acc"),
                        HeadingAcc = reader.GetField<int?>("Heading Acc"),
                        Interceptions = reader.GetField<int?>("Interceptions"),
                        LongPass = reader.GetField<int?>("Long Pass"),
                        PAC = reader.GetField<int?>("PAC"),
                        PAS = reader.GetField<int?>("PAS"),
                        PHY = reader.GetField<int?>("PHY"),
                        SHO = reader.GetField<int?>("SHO"),
                        ShortPass = reader.GetField<int?>("Short Pass"),
                        StandTackle = reader.GetField<int?>("Stand Tackle"),
                        Vision = reader.GetField<int?>("Vision"),
                        DIV = reader.GetField<int?>("DIV"),
                        GKDiving = reader.GetField<int?>("GK Diving"),
                        GKHandling = reader.GetField<int?>("GK Handling"),
                        GKKicking = reader.GetField<int?>("GK Kicking"),
                        GKPos = reader.GetField<int?>("GK Pos"),
                        GKReflexes = reader.GetField<int?>("GK Reflexes"),
                        HAN = reader.GetField<int?>("HAN"),
                        KIC = reader.GetField<int?>("KIC"),
                        POS = reader.GetField<int?>("POS"),
                        REF = reader.GetField<int?>("REF"),
                        SPD = reader.GetField<int?>("SPD"),
                    };
            }
        }
    }
}