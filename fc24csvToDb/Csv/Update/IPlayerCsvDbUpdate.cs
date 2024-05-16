namespace fc24csvToDb.Csv.Update;

public interface IPlayerCsvDbUpdate
{
    public void UpdateAcceleRate();
    public void UpdateBodytype();
    public void UpdateCard();
    public void UpdateClub();
    public void UpdateLeague();
    public void UpdateNationality();
    public void UpdatePlayer();
    public void UpdatePlaystyle();
    public void UpdateVersion();
    public void UpdatePosition();

    public void UpdateAll();
}