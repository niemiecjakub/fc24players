using fcLogoScraper;

public class Program
{
    static async Task Main(string[] args)
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

        // string folderPath = @"C:\Users\komputerek\Desktop\clubFcLogos";
        // string folderPath = @"C:\Users\komputerek\Desktop\leagueFcLogos";
        // LogoScraper logoScraper = new LogoScraper(folderPath);
        // LogoScraperFacade clubLogoScraperFacade = new LogoScraperFacade(logoScraper);

        // List<String> clubNames = dbManager.GetClubNames();
        // IEnumerable<String> alreadyScrapedClubs = Directory.GetFiles(folderPath).Select(path => Path.GetFileNameWithoutExtension(path));
        // clubNames = clubNames.Where(club => !alreadyScrapedClubs.Contains(club)).ToList();
        // foreach (string clubName in clubNames)
        // {
        //     clubLogoScraperFacade.Scrape(clubName);
        // }

        // List<String> leagueNames = dbManager.GetLeagueNames();
        // foreach (string leagueName in leagueNames)
        // {
        //     clubLogoScraperFacade.Scrape(leagueName);
        // }

        ClubInfoScraper clubInfoScraper = new ClubInfoScraper();
        List<String> clubNames = dbManager.GetClubNames();

        string clubName = "Cork City";
        ClubInfo clubInfo = clubInfoScraper.Scrape(clubName);
        dbManager.CreateManager(clubInfo.ManagerName, clubInfo.ManagerNationality, clubName);
        dbManager.CreateLeagueClub(clubName, clubInfo.League);
        dbManager.UpdateClubInfo(clubInfo);


        // foreach (string clubName in clubNames)
        // {
        //     try
        //     {
        //         ClubInfo clubInfo = clubInfoScraper.Scrape(clubName);
        //         dbManager.CreateManager(clubInfo.ManagerName, clubInfo.ManagerNationality, clubName);
        //         dbManager.CreateLeagueClub(clubName, clubInfo.League);
        //         dbManager.UpdateClubInfo(clubInfo);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine($"ERROR FOR {clubName}");
        //     }
        // }
    }
}