namespace fcLogoScraper;

public class LogoScraperFacade(LogoScraper logoScraper)
{
   public void Scrape(string clubName)
   {
      bool result = logoScraper.SearchGoogleForWikipediaSvgResult(clubName);
      if (!result)
      {
         logoScraper.SearchWikipediaPage(clubName);
      }
   }
}