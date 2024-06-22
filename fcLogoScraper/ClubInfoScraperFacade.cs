namespace fcLogoScraper;

public class ClubInfoScraperFacade(ClubInfoScraper clubInfoScraper, DbManager dbManager)
{
    public void Scrape(string clubName)
    {
        ClubInfo clubInfo = clubInfoScraper.Scrape(clubName);
        dbManager.UpdateClubInfo(clubInfo);
    }
}