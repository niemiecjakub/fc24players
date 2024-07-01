using dbUpdate.ClubLogoScraper;
using dbUpdate.Db;
using dbUpdate.SoccerWiki;
using fc24csvToDb.Csv;
using fc24csvToDb.Csv.Update;

public class Program
{
    static void Main(string[] args)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string relativePath = @"C:\Users\komputerek\source\repos\fc24players\fc24players\fc24cards.db";
        string dbPath = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        Console.WriteLine($"Database path: {dbPath}");
        
        if (!File.Exists(dbPath))
        {
            Console.WriteLine("Database file not found!");
            return;
        }

        string connectionString = $"Data Source={dbPath}";
        DbManager dbManager = new DbManager(connectionString);
        
        
        string csvFilePath = @"C:\Users\komputerek\source\repos\fc24players\dbUpdate\Data\fut_players.csv";
        PlayerPlayerCsvReader playerCsvReader = new PlayerPlayerCsvReader(csvFilePath);
        PlayerCsvDbUpdate playerCsvDbUpdate = new PlayerCsvDbUpdate(connectionString, playerCsvReader);
        playerCsvDbUpdate.UpdateAll();

        
        string clubFolderPath = @"C:\Users\komputerek\Desktop\clubFcLogos";
        string leagueFolderPath = @"C:\Users\komputerek\Desktop\leagueFcLogos";
        WikipediaScraper wikipediaScraper = new WikipediaScraper(clubFolderPath);
        WikipediaScraperFacade wikipediaScraperFacade = new WikipediaScraperFacade(wikipediaScraper);
        List<String> clubNames = dbManager.GetClubNames();
        IEnumerable<String> alreadyScrapedClubs = Directory.GetFiles(clubFolderPath).Select(path => Path.GetFileNameWithoutExtension(path));
        clubNames = clubNames.Where(club => !alreadyScrapedClubs.Contains(club)).ToList();
        foreach (string clubName in clubNames)
        {
            wikipediaScraperFacade.Scrape(clubName);
        }
        List<String> leagueNames = dbManager.GetLeagueNames();
        IEnumerable<String> alreadyScrapedLeagues = Directory.GetFiles(leagueFolderPath).Select(path => Path.GetFileNameWithoutExtension(path));
        leagueNames = leagueNames.Where(league => !alreadyScrapedLeagues.Contains(league)).ToList();
        foreach (string leagueName in leagueNames)
        {
            wikipediaScraperFacade.Scrape(leagueName);
        }
        

        SoccerWikiScraper soccerWikiScraper = new SoccerWikiScraper();
        SoccerWikiScraperFacade soccerWikiScraperFacade = new SoccerWikiScraperFacade(soccerWikiScraper, dbManager);
        soccerWikiScraperFacade.ScrapeAndUpdateAllClubs();
        
    }
}
