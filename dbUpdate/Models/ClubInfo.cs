namespace dbUpdate.Models;

public class ClubInfo
{
    public string ClubName;
    public string? ManagerName;
    public string? ManagerNationality;
    public string Code;
    public string Stadium;
    public string League;
    public string Nationality;
    public int YearFounded;
    public string Location;
    public string ClubAltName;
    public string LeagueAltName;

    public override string ToString()
    {
        return $"---------------------- \n" +
               $"ClubName: {ClubName} \n" +
               $"AltName : {ClubAltName} \n" +
               $"League AltName: {LeagueAltName} \n" +
               $"Year Founded: {YearFounded} \n" +
               $"Manager Name: {ManagerName} \n" +
               $"Manager Nationality: {ManagerNationality} \n" +
               $"Code: {Code} \n" +
               $"Stadium: {Stadium} \n" +
               $"League: {League} \n" +
               $"Nationality: {Nationality} \n" +
               $"Location: {Location} \n";
    }
}