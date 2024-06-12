using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
    
    public void GoogleSearch(string query)
    {
        Driver.Navigate().GoToUrl($"https://www.google.com/search?q={query}");
        HandleGooglePopup();
    }
    
    public void WikipediaSearch(string query)
    {
        query = query.Replace(" ", "_");
        Driver.Navigate().GoToUrl($"https://en.wikipedia.org/wiki/{query}");
    }


    public bool SearchGoogleForWikipediaSvgResult(string clubName)
    {
        try
        {
            GoogleSearch($"{clubName} logo svg");
            ReadOnlyCollection<IWebElement> webElements = Driver.FindElements(By.CssSelector("div div div div div a"));
            IWebElement? webElement = webElements
                .Where(webElement => !string.IsNullOrEmpty(webElement.GetAttribute("href")))
                .FirstOrDefault(webElement => webElement.GetAttribute("href").Contains("wiki"));

            if (webElement == null)
            {
                return false;
            }
            webElement.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement? imageWebElement = Driver.FindElement(By.CssSelector(".fullImageLink a"));
            
            if (imageWebElement == null)
            {
                return false;
            }
            
            imageWebElement.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            if (!Driver.PageSource.Contains("svg"))
            {
                return false;
            }
            
            SaveSvg(clubName);
            return true;
            
        }
        catch (Exception ne)
        {
            Console.WriteLine($"error for {clubName}");
            return false;
        }
    }


    public bool SearchWikipediaPage(string clubName)
    {
        try
        {
            WikipediaSearch(clubName);
            IWebElement? webElement = Driver.FindElement(By.CssSelector(".mw-file-description"));
            
            if (webElement != null)
            {
                string imageurl = webElement.GetAttribute("href");
                Driver.Navigate().GoToUrl(imageurl);
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                IWebElement? imageWebElement = Driver.FindElement(By.CssSelector(".fullImageLink a"));
        
                if (imageWebElement == null)
                {
                    return false;
                }
        
                string imageUrl = webElement.GetAttribute("href");
                Driver.Navigate().GoToUrl(imageUrl);
        
                if (!Driver.PageSource.Contains("svg"))
                {
                    return false;
                }
        
                SaveSvg(clubName);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    
    private void SaveSvg(string fileName)
    {
        string filePath = Path.Combine(FolderPath, $"{fileName}.svg");
        File.WriteAllText(filePath, Driver.PageSource);
        Console.WriteLine($"saved image: {fileName}");
    }
    
    private async Task DownloadImageAsync(string imageUrl, string fileName)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(imageUrl);
            byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
            string filePath = Path.Combine(FolderPath, fileName);
            Directory.CreateDirectory(FolderPath);
            await File.WriteAllBytesAsync(filePath, imageBytes);
        }
    }
}