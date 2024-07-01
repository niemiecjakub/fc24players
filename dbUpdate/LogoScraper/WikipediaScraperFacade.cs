namespace dbUpdate.ClubLogoScraper;

public class WikipediaScraperFacade(WikipediaScraper wikipediaScraper)
{
    public void Scrape(string clubName)
    {
        bool result = wikipediaScraper.SearchGoogleForWikipediaSvgResult(clubName);
        if (!result)
        {
            wikipediaScraper.SearchWikipediaPage(clubName);
        }
    }
}