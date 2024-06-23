using fc24players.Models;
using Version = fc24players.Models.Version;

namespace fc24csvToDb.Csv;

public interface IPlayerCsvReader
{
    public IEnumerable<AcceleRate> ReadAcceleRate();
    public IEnumerable<List<Bodytype>> ReadBodytype();
    public IEnumerable<Card> ReadCard();
    public IEnumerable<Club> ReadClub();
    public IEnumerable<League> ReadLeague();
    public IEnumerable<Nationality> ReadNationality();
    public IEnumerable<Player> ReadPlayer();
    public IEnumerable<Playstyle> ReadPlaystyle();
    public IEnumerable<Version> ReadVersion();
    public IEnumerable<List<Position>> ReadPosition();
    public IEnumerable<List<CardAltpos>> ReadCardAltpos();
    public IEnumerable<List<CardBodytype>> ReadCardBodytype();
    public IEnumerable<List<CardPlaystyle>> ReadCardPlaystyle();
    public IEnumerable<List<CardPlayStylePlus>> ReadCardPlaystylePlus();

}