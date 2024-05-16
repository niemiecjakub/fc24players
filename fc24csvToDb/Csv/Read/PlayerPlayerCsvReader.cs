using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
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
                    Name = acceleRate
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
                    Name = version
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
        //TODO
        throw new NotImplementedException();
    }
}