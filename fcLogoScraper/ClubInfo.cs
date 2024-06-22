namespace fcLogoScraper;

public class ClubInfo
{
    public string ClubName;
    public string Manager;
    public string Code;
    public string Stadium;
    public string League;
    public string Nationality;

    public override string ToString()
    {
        return $"------ \n" +
               $"ClubName: {ClubName} \n" +
               $"Manager: {Manager} \n" +
               $"Code: {Code} \n" +
               $"Stadium: {Stadium} \n" +
               $"League: {League} \n" +
               $"Nationality: {Nationality}";
    }
}