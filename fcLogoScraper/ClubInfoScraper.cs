using System.Collections.ObjectModel;
using fc24players.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace fcLogoScraper;

public class ClubInfoScraper
{
    private IWebDriver Driver = new ChromeDriver();
    private string BaseUrl = "https://en.soccerwiki.org/squad.php";
    
    private void SearchClub(string clubName)
    {
        Driver.Navigate().GoToUrl(BaseUrl);
        IWebElement searchContainer = Driver.FindElement(By.CssSelector("div.rd-search-modern"));
        searchContainer.FindElement(By.CssSelector("div.form-wrap input")).SendKeys(clubName);
        searchContainer.FindElement(By.CssSelector("button")).Click();
        Driver.FindElement(By.CssSelector("tbody tr:first-child td")).Click();
    }

    private ClubInfo GetClubInfo(string clubName)
    {
        ReadOnlyCollection<IWebElement> clubInfo = Driver.FindElements(By.CssSelector("p.player-info-subtitle"));
        IWebElement manager = clubInfo.First(info => info.Text.Contains("MANAGER"));

        string code = clubInfo.First(info => info.Text.Contains("SHORT")).Text.GetValue();
        string league = clubInfo.First(info => info.Text.Contains("LEAGUE")).Text.GetValue().ToPascalCase();
        string stadium = clubInfo.First(info => info.Text.Contains("STADIUM")).Text.GetValue().GetStadium().ToPascalCase();
        string nationality = clubInfo.First(info => info.Text.Contains("COUNTRY")).Text.GetValue().ToPascalCase();
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
            Nationality = nationality
        };
    }

    public ClubInfo Scrape(string clubName)
    { 
        SearchClub(clubName);
        ClubInfo clubInfo = GetClubInfo(clubName);
        Console.WriteLine(clubInfo);
        
        return clubInfo;
    }
}