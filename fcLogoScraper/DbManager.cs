using Microsoft.Data.Sqlite;

namespace fcLogoScraper;

public class DbManager(string connectionString)
{
    public List<String> GetClubNames()
    {
        List<String> clubNames = new List<string>();
        var clubsSql = "SELECT Name FROM Club";


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


        return clubNames;
    }

    public List<String> GetLeagueNames()
    {
        List<String> leagueNames = new List<string>();
        var leagueSql = "SELECT Name FROM League";


        using (var connection = new SqliteConnection(connectionString))
        {
            var command = connection.CreateCommand();
            command.CommandText = leagueSql;
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string clubName = reader.GetString(0);
                    leagueNames.Add(clubName);
                }
            }
        }


        return leagueNames;
    }

    public void UpdateClubInfo(ClubInfo clubInfo)
    {
        var updateSql =
            "UPDATE Club SET Code = @code, NationalityId = @nationalityId, ManagerId = @managerId,  Stadium = @stadium WHERE Name = @name";


        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var nationalityId = GetEntityId(connection, "Nationality", clubInfo.Nationality);
            var managerId = GetEntityId(connection, "Manager", clubInfo.ManagerName);

            using var updateCommand = new SqliteCommand(updateSql, connection);
            updateCommand.Parameters.AddWithValue("@name", clubInfo.ClubName);
            updateCommand.Parameters.AddWithValue("@code", clubInfo.Code);
            updateCommand.Parameters.AddWithValue("@stadium", clubInfo.Stadium);
            updateCommand.Parameters.AddWithValue("@nationalityId", nationalityId);
            updateCommand.Parameters.AddWithValue("@managerId", managerId);
            updateCommand.ExecuteNonQuery();
        }
    }


    public void CreateLeagueClub(string clubName, string leagueName)
    {
        var insertSql = "INSERT INTO LeagueClub(ClubId, LeagueId) VALUES (@clubId, @leagueId)";
        var checkExistenceSql = "SELECT COUNT(*) FROM LeagueClub WHERE ClubId = @clubId AND LeagueId = @leagueId";


        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var clubId = GetEntityId(connection, "Club", clubName);
            var leagueId = GetEntityId(connection, "League", leagueName);

            using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
            checkCommand.Parameters.AddWithValue("@clubId", clubId);
            checkCommand.Parameters.AddWithValue("@leagueId", leagueId);

            var exists = (long)checkCommand.ExecuteScalar() > 0;

            if (!exists)
            {
                using var insertCommand = new SqliteCommand(insertSql, connection);
                insertCommand.Parameters.AddWithValue("@clubId", clubId);
                insertCommand.Parameters.AddWithValue("@leagueId", leagueId);
                insertCommand.ExecuteNonQuery();
            }
        }
    }

    public void CreateManager(string managerName, string managerNationality, string clubName)
    {
        var insertSql = "INSERT INTO Manager(Name, NationalityId, ClubId) VALUES (@name, @nationalityId, @clubId)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Manager WHERE Name = @name";


        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var nationalityId = GetEntityId(connection, "Nationality", managerNationality);
            var clubId = GetEntityId(connection, "Club", clubName);

            using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
            checkCommand.Parameters.AddWithValue("@name", managerName);

            var exists = (long)checkCommand.ExecuteScalar() > 0;

            if (!exists)
            {
                using var insertCommand = new SqliteCommand(insertSql, connection);
                insertCommand.Parameters.AddWithValue("@name", managerName);
                insertCommand.Parameters.AddWithValue("@nationalityId", nationalityId);
                insertCommand.Parameters.AddWithValue("@clubId", clubId);
                insertCommand.ExecuteNonQuery();
            }
        }
    }

    public long? GetEntityId(SqliteConnection connection, string tableName, string name)
    {
        connection.Open();
        var selectEntitySql = $"SELECT Id FROM {tableName} WHERE Name = @name";
        using var selectCommand = new SqliteCommand(selectEntitySql, connection);
        selectCommand.Parameters.AddWithValue("@name", name);
        return (long?)selectCommand.ExecuteScalar();
    }
}