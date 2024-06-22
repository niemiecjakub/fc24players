using System.Globalization;

namespace fcLogoScraper;

public static class ClubInfoExtension
{
    public static string GetValue(this string text)
    {
        return text.Split(":")[1].Trim();
    }
    
    public static string GetStadium(this string text)
    {
        return text.Split("(")[0].Trim();
    }

    public static string ToPascalCase(this string text)
    {
        String[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        IEnumerable<string> pascalCaseWords = words.Select(word => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower()));
        return string.Join(" ", pascalCaseWords);
    }
}