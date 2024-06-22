using fc24players.Models;

namespace fcLogoScraper;

public class ClubInfo
{
    public string ClubName;
    public string ManagerName;
    public string ManagerNationality;
    public string Code;
    public string Stadium;
    public string League;
    public string Nationality;

    public override string ToString()
    {
        return $"---------------------- \n" +
               $"ClubName: {ClubName} \n" +
               $"Manager Name: {ManagerName} \n" +
               $"Manager Nationality: {ManagerNationality} \n" +
               $"Code: {Code} \n" +
               $"Stadium: {Stadium} \n" +
               $"League: {League} \n" +
               $"Nationality: {Nationality}";
    }
}