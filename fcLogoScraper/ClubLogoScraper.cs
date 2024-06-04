using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace fcLogoScraper;

public class ClubLogoScraper
{
    private string FolderPath;
    private IWebDriver Driver;

    public ClubLogoScraper(string folderPath)
    {
        FolderPath = folderPath;
        Driver = new ChromeDriver();
    }

    private void HandleGooglePopup()
    {
        try
        {
            IWebElement googlePopup = Driver.FindElement(By.XPath("//*[@id=\"L2AGLb\"]"));
            if (googlePopup.Displayed)
            {
                googlePopup.Click();
            }
        }
        catch (NoSuchElementException e)
        {
            
        }
    }

    public String GoogleSearchWikipediaResult(string clubName)
    {
        try
        {
            String googleSearchQuery = $"{clubName} svg logo wikipedia";
            Driver.Navigate().GoToUrl($"https://www.google.com/search?q={googleSearchQuery}");
            HandleGooglePopup();

            Console.Out.WriteLine("HERE");
            IWebElement webElements = Driver.FindElement(By.CssSelector("h3"));
            webElements.Click();
            return Driver.Url;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
            return "";
        }
    }
    
    public void Scrape(string url, string clubName)
    {
        try
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement webElement = Driver.FindElement(By.CssSelector(".fullImageLink a"));
            string imageUrl = webElement.GetAttribute("href");
            // await DownloadImageAsync(imageUrl,$"{clubName}.svg");

            SaveSvg(imageUrl, clubName);
        }
        catch (Exception e)
        {
            
        }
    }

    private async Task DownloadImageAsync(string imageUrl, string fileName)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(imageUrl);
            // response.EnsureSuccessStatusCode();
            byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
            string filePath = Path.Combine(FolderPath, fileName);
            Directory.CreateDirectory(FolderPath);
            await File.WriteAllBytesAsync(filePath, imageBytes);
        }
    }
    
    private void SaveSvg(string imageUrl, string fileName)
    {
       Driver.Navigate().GoToUrl(imageUrl);
       String pageSource = Driver.PageSource;
       WriteFile($"{fileName}.svg", pageSource);
       
    }

    public void WriteFile(string fileName, string content)
    {
        string filePath = Path.Combine(FolderPath, fileName);

        File.WriteAllText(filePath, content);
        if (File.Exists(filePath))
        {
            Console.WriteLine("File created successfully.");
        }
        else
        {
            Console.WriteLine("Error: File creation failed.");
        }
    }

}