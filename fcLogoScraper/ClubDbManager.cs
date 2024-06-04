using Microsoft.Data.Sqlite;

namespace fcLogoScraper;

public class ClubDbManager(string connectionString)
{
    public List<String> GetClubNames()
    {
        List<String> clubNames = new List<string>();
        var clubsSql = "SELECT Name FROM Club";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = clubsSql;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string clubName = reader.GetString(0);
                        clubNames.Add(clubName);
                    }
                }
            }

            
        }
        catch (SqliteException exception)
        {
            Console.WriteLine($"Error: {exception}");
        }
        return clubNames;
    }
}