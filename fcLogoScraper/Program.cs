
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
        
        string folderPath = @"C:\Users\komputerek\Desktop\fcLogos";
        ClubLogoScraper clubLogoScraper = new ClubLogoScraper(folderPath);
        ClubDbManager clubDbManager = new ClubDbManager(connectionString);
        ClubLogoScraperFacade clubLogoScraperFacade = new ClubLogoScraperFacade(clubLogoScraper);
        
        List<String> clubNames = clubDbManager.GetClubNames();
        IEnumerable<String> alreadyScrapedClubs = Directory.GetFiles(folderPath).Select(path => Path.GetFileNameWithoutExtension(path));
        clubNames = clubNames.Where(club => !alreadyScrapedClubs.Contains(club)).ToList();
        
        foreach (string clubName in clubNames)
        {
            clubLogoScraperFacade.Scrape(clubName);
        }
    }
}