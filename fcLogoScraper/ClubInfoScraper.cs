using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace fcLogoScraper;

public class ClubInfoScraper
{
    private DbManager DbManager;
    private IWebDriver Driver;
    private string BaseUrl = "https://en.soccerwiki.org/squad.php";

    public ClubInfoScraper(DbManager dbManager)
    {
        Driver = new ChromeDriver();
        DbManager = dbManager;
    }

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

        string manager = clubInfo.First(info => info.Text.Contains("MANAGER")).Text.GetValue().ToPascalCase();
        string code = clubInfo.First(info => info.Text.Contains("SHORT")).Text.GetValue();
        string league = clubInfo.First(info => info.Text.Contains("LEAGUE")).Text.GetValue().ToPascalCase();
        string stadium = clubInfo.First(info => info.Text.Contains("STADIUM")).Text.GetValue().GetStadium().ToPascalCase();
        string nationality = clubInfo.First(info => info.Text.Contains("COUNTRY")).Text.GetValue().ToPascalCase();

        return new ClubInfo()
        {
            ClubName = clubName,
            Manager = manager,
            Code = code,
            League = league,
            Stadium = stadium,
            Nationality = nationality
        };
    }

    public void Scrape(string clubName)
    {
        try
        {
            SearchClub(clubName);
            ClubInfo clubInfo = GetClubInfo(clubName);
            Console.WriteLine(clubInfo);
            DbManager.UpdateClubInfo(clubInfo);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Cannot find club {clubName}");
        }
    }
}