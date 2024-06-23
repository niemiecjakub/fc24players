using dbUpdate.Csv;
using dbUpdate.Db;
using dbUpdate.Models;
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
        //
        string connectionString = $"Data Source={dbPath}";
        string csvFilePath = @"C:\Users\komputerek\source\repos\fc24players\dbUpdate\Data\fut_players.csv";
        //
        // PlayerPlayerCsvReader playerCsvReader = new PlayerPlayerCsvReader(csvFilePath);
        // PlayerCsvDbUpdate playerCsvDbUpdate = new PlayerCsvDbUpdate(connectionString, playerCsvReader);
        // playerCsvDbUpdate.UpdateAll();

        DbUpdate dbUpdate = new DbUpdate(connectionString);
        SoccerWikiScraper soccerWikiScraper = new SoccerWikiScraper();

        List<string> clubNames = dbUpdate.GetClubNames();
        foreach (string clubName in clubNames)
        {
            try
            {
                ClubInfo clubInfo = soccerWikiScraper.ScrapeClub(clubName);
                if (clubInfo.ManagerName is not null)
                {
                    dbUpdate.CreateManager(clubInfo.ManagerName, clubInfo.ManagerNationality, clubInfo.ClubName);
                }
                dbUpdate.UpdateClubInfo(clubInfo);
                Console.WriteLine($"Successfully scraped: {clubName}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error for: {clubName}");
            }
        }
        
        
        

    }
}
