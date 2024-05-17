using System.Text.RegularExpressions;

namespace fc24csvToDb.Helpers;

public static class StringExtension
{
    public static int GetHeightInCm(this string value)
    {
        return value.Split("/")[1].Trim().StripUnits();
    }
    
    public static int StripUnits(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Input string cannot be null or empty.", nameof(value));
        }
        
        var regex = new Regex(@"\d+");
        var match = regex.Match(value);

        if (match.Success && int.TryParse(match.Value, out int result))
        {
            return result;
        }

        throw new FormatException("No valid number found in the input string.");
    }
}