using dbUpdate.Db;
using dbUpdate.Models;

namespace dbUpdate.SoccerWiki;

public class SoccerWikiScraperFacade
{
    private SoccerWikiScraper SoccerWikiScraper;
    private DbUpdate DbUpdate;

    public SoccerWikiScraperFacade(SoccerWikiScraper soccerWikiScraper, DbUpdate dbUpdate)
    {
        SoccerWikiScraper = soccerWikiScraper;
        DbUpdate = dbUpdate;
    }
    
    public void ScrapeAndUpdateAllClubs()
    {
        List<string> clubNames = DbUpdate.GetClubNames();
        foreach (string clubName in clubNames)
        {
            ScrapeAndUpdateClub(clubName);
        }
    }

    public void ScrapeAndUpdateClub(string clubName)
    {
        try
        {
            ClubInfo clubInfo = SoccerWikiScraper.ScrapeClub(clubName);
            if (clubInfo.ManagerName is not null)
            {
                DbUpdate.CreateManager(clubInfo.ManagerName, clubInfo.ManagerNationality, clubInfo.ClubName);
            }
            DbUpdate.UpdateClubInfo(clubInfo);
            Console.WriteLine($"Successfully scraped: {clubName}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error for: {clubName}");
        }
    }
}