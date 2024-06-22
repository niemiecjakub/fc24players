
using fcLogoScraper;

public class Program
{
    static async Task  Main(string[] args)
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
        
        // string folderPath = @"C:\Users\komputerek\Desktop\clubFcLogos";
        string folderPath = @"C:\Users\komputerek\Desktop\leagueFcLogos";
        LogoScraper logoScraper = new LogoScraper(folderPath);
        DbManager dbManager = new DbManager(connectionString);
        LogoScraperFacade clubLogoScraperFacade = new LogoScraperFacade(logoScraper);
        
        // List<String> clubNames = dbManager.GetClubNames();
        // IEnumerable<String> alreadyScrapedClubs = Directory.GetFiles(folderPath).Select(path => Path.GetFileNameWithoutExtension(path));
        // clubNames = clubNames.Where(club => !alreadyScrapedClubs.Contains(club)).ToList();
        // foreach (string clubName in leagueNames)
        // {
        //     clubLogoScraperFacade.Scrape(clubName);
        // }
        
        List<String> leagueNames = dbManager.GetLeagueNames();
        foreach (string leagueName in leagueNames)
        {
            clubLogoScraperFacade.Scrape(leagueName);
        }
    }
}