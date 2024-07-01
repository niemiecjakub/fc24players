using dbUpdate.Db;
using dbUpdate.Models;

namespace dbUpdate.SoccerWiki;

public class SoccerWikiScraperFacade(SoccerWikiScraper soccerWikiScraper, DbManager dbManager)
{
    
    public void ScrapeAndUpdateAllClubs()
    {
        List<string> clubNames = dbManager.GetClubNames();
        foreach (string clubName in clubNames)
        {
            ScrapeAndUpdateClub(clubName);
        }
    }

    public void ScrapeAndUpdateClub(string clubName)
    {
        try
        {
            ClubInfo clubInfo = soccerWikiScraper.ScrapeClub(clubName);
            if (clubInfo.ManagerName is not null)
            {
                dbManager.CreateManager(clubInfo.ManagerName, clubInfo.ManagerNationality, clubInfo.ClubName);
            }
            dbManager.UpdateClubInfo(clubInfo);
            Console.WriteLine($"Successfully scraped: {clubName}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error for: {clubName}");
        }
    }
}