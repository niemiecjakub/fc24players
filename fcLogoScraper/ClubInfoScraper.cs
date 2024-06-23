using System.Collections.ObjectModel;
using fc24players.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace fcLogoScraper;

public class ClubInfoScraper
{
    private IWebDriver Driver = new ChromeDriver();
    private string ClubSearchUrl = "https://en.soccerwiki.org/search.php?type=club&q=";
    private string PlayerSearchUrl = "https://en.soccerwiki.org/squad.php?type=player&q=";
    
    private void SearchClub(string clubName)
    {
        Driver.Navigate().GoToUrl(ClubSearchUrl + clubName);
    }

    public void SearchPlayer(string playerName)
    {
        Driver.Navigate().GoToUrl(PlayerSearchUrl + playerName);
    }

    public void Search(string searchType, string name)
    {
        Driver.Navigate().GoToUrl($"https://en.soccerwiki.org/search.php?type={searchType}&q={name}");
        ReadOnlyCollection<IWebElement> headers = Driver.FindElements(By.CssSelector("th"));
        int columnNumber = 1;

        foreach (IWebElement header in headers)
        {
            if (header.Text.ToUpper().Contains($"{searchType.ToUpper()}"))
            {
                break;
            };
            columnNumber++;
        }
        IWebElement firstResult = Driver.FindElement(By.CssSelector("tbody tr:nth-child(1)"));
        firstResult.FindElement(By.CssSelector($"td:nth-child({columnNumber}) a")).Click();
    }

    private ClubInfo GetClubInfo(string clubName)
    {
        ReadOnlyCollection<IWebElement> clubInfo = Driver.FindElements(By.CssSelector("p.player-info-subtitle"));
        IWebElement manager = clubInfo.First(info => info.Text.Contains("MANAGER"));

        string code = clubInfo.First(info => info.Text.Contains("SHORT")).Text.GetValue();
        string league = clubInfo.First(info => info.Text.Contains("LEAGUE")).Text.GetValue().ToPascalCase();
        string stadium = clubInfo.First(info => info.Text.Contains("STADIUM")).Text.GetValue().GetStadium().ToPascalCase();
        string nationality = clubInfo.First(info => info.Text.Contains("COUNTRY")).Text.GetValue().ToPascalCase();
        int yearFounded = Convert.ToInt32(clubInfo.First(info => info.Text.Contains("YEAR FOUNDED")).Text.GetValue());
        string location = clubInfo.First(info => info.Text.Contains("LOCATION")).Text.GetValue().ToPascalCase();
        string clubAltName = clubInfo.First(info => info.Text.Contains("MEDIUM NAME")).Text.GetValue().ToPascalCase();
        string leagueAltName = clubInfo.First(info => info.Text.Contains("LEAGUE")).Text.GetValue().ToPascalCase();
        string managerName = manager.Text.GetValue().ToPascalCase();
        string managerNationality = manager.FindElement(By.CssSelector("a")).GetAttribute("data-original-title");
        
        return new ClubInfo()
        {
            ClubName = clubName,
            ManagerName = managerName,
            ManagerNationality = managerNationality,
            Code = code,
            League = league,
            Stadium = stadium,
            Nationality = nationality,
            YearFounded = yearFounded,
            Location = location,
            ClubAltName = clubAltName,
            LeagueAltName = leagueAltName
        };
    }

    public ClubInfo ScrapeClub(string clubName)
    { 
        SearchClub(clubName);
        ClubInfo clubInfo = GetClubInfo(clubName);
        Console.WriteLine(clubInfo);
        
        return clubInfo;
    }
    
    public ClubInfo ScrapeClubFromPlayer(string playerName)
    { 
        Search("player", playerName);
        IWebElement club = Driver.FindElements(By.CssSelector(".player-info-subtitle")).First(e => e.Text.Contains("CLUB")).FindElement(By.CssSelector("a"));
        string clubName = club.Text;
        club.Click();
        return GetClubInfo(clubName);

    }
}