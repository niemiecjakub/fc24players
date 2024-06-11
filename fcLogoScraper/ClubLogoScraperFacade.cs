namespace fcLogoScraper;

public class ClubLogoScraperFacade(ClubLogoScraper clubLogoScraper)
{
   public void Scrape(string clubName)
   {
      bool result = clubLogoScraper.SearchGoogleForWikipediaSvgResult(clubName);
      if (!result)
      {
         clubLogoScraper.SearchWikipediaPage(clubName);
      }
   }
}