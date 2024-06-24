using dbUpdate.Db;
using dbUpdate.Models;
using dbUpdate.SoccerWiki;

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
        //
        string connectionString = $"Data Source={dbPath}";
        string csvFilePath = @"C:\Users\komputerek\source\repos\fc24players\dbUpdate\Data\fut_players.csv";
        //
        // PlayerPlayerCsvReader playerCsvReader = new PlayerPlayerCsvReader(csvFilePath);
        // PlayerCsvDbUpdate playerCsvDbUpdate = new PlayerCsvDbUpdate(connectionString, playerCsvReader);
        // playerCsvDbUpdate.UpdateAll();

        DbUpdate dbUpdate = new DbUpdate(connectionString);
        SoccerWikiScraper soccerWikiScraper = new SoccerWikiScraper();
        SoccerWikiScraperFacade soccerWikiScraperFacade = new SoccerWikiScraperFacade(soccerWikiScraper, dbUpdate);
        soccerWikiScraperFacade.ScrapeAndUpdateAllClubs();
        
        
        
    }
}
