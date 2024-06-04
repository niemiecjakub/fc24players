
using fcLogoScraper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        
        
        List<String> clubNames = clubDbManager.GetClubNames();
        
        foreach (string clubName in clubNames)
        {
            // String clubName = clubNames[1];
            string wikipediaUrl = clubLogoScraper.GoogleSearchWikipediaResult(clubName);
            Console.WriteLine(wikipediaUrl);
            if (wikipediaUrl.Contains("wikipedia"))
            {
                clubLogoScraper.Scrape(wikipediaUrl, clubName);
            }
        }
        
        
    }
}