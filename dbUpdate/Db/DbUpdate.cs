using dbUpdate.Models;
using Microsoft.Data.Sqlite;

namespace dbUpdate.Db;

public class DbUpdate(string connectionString)
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
    
    public void UpdateClubInfo(ClubInfo clubInfo)
    {
        var updateSql = "UPDATE Club SET Code = @code,NationalityId = @nationalityId, ManagerId = @managerId,Stadium = @stadium, AltName = @altName,  YearFounded = @yearFounded,  Location = @location WHERE Name = @name";
        
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var nationalityId = GetEntityId(connection, "Nationality", clubInfo.Nationality);
            long? managerId = clubInfo.ManagerName is not null ? GetEntityId(connection, "Manager", clubInfo.ManagerName) : null;
            
            using var updateCommand = new SqliteCommand(updateSql, connection);
            updateCommand.Parameters.AddWithValue("@name", clubInfo.ClubName);
            updateCommand.Parameters.AddWithValue("@code", clubInfo.Code);
            updateCommand.Parameters.AddWithValue("@stadium", clubInfo.Stadium);
            updateCommand.Parameters.AddWithValue("@altName", clubInfo.ClubAltName);
            updateCommand.Parameters.AddWithValue("@yearFounded", clubInfo.YearFounded);
            updateCommand.Parameters.AddWithValue("@location", clubInfo.Location);
            updateCommand.Parameters.AddWithValue("@nationalityId", nationalityId);
            updateCommand.Parameters.AddWithValue("@managerId", managerId ?? (object)DBNull.Value);
            updateCommand.ExecuteNonQuery();
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
    
    public long GetEntityId(SqliteConnection connection, string tableName, string name)
    {
        connection.Open();
        var selectEntitySql = $"SELECT Id FROM {tableName} WHERE Name = @name";
        using var selectCommand = new SqliteCommand(selectEntitySql, connection);
        selectCommand.Parameters.AddWithValue("@name", name);
        return (long)selectCommand.ExecuteScalar();
    }
}