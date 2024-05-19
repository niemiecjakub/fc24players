using Microsoft.Data.Sqlite;

namespace fc24csvToDb.Csv.Update;

public class PlayerCsvDbUpdate(string connectionString, IPlayerCsvReader playerCsvReader) : IPlayerCsvDbUpdate
{
    public void UpdateAll()
    {
        // UpdateAcceleRate();
        // UpdateBodytype();
        // UpdateClub();
        // UpdateLeague();
        // UpdateNationality();
        // UpdatePlaystyle();
        // UpdateVersion();
        // UpdatePosition();
        // UpdatePosition();
        // UpdatePlayer();

        // UpdateCard();
    }

    public void UpdateAcceleRate()
    {
        var insertSql = "INSERT INTO AcceleRate(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM AcceleRate WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var acceleRate in playerCsvReader.ReadAcceleRate())
                {
                    using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                    checkCommand.Parameters.AddWithValue("@name", acceleRate.Name);

                    var exists = (long)checkCommand.ExecuteScalar() > 0;

                    if (!exists)
                    {
                        using var insertCommand = new SqliteCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@name", acceleRate.Name);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdateBodytype()
    {
        var insertSql = "INSERT INTO Bodytype(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Bodytype WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var bodytypeList in playerCsvReader.ReadBodytype())
                {
                    foreach (var bodytype in bodytypeList)
                    {
                        using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                        checkCommand.Parameters.AddWithValue("@name", bodytype.Name);

                        var exists = (long)checkCommand.ExecuteScalar() > 0;

                        if (!exists)
                        {
                            using var insertCommand = new SqliteCommand(insertSql, connection);
                            insertCommand.Parameters.AddWithValue("@name", bodytype.Name);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdateClub()
    {
        var insertSql = "INSERT INTO Club(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Club WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var version in playerCsvReader.ReadClub())
                {
                    using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                    checkCommand.Parameters.AddWithValue("@name", version.Name);

                    var exists = (long)checkCommand.ExecuteScalar() > 0;

                    if (!exists)
                    {
                        using var insertCommand = new SqliteCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@name", version.Name);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdateLeague()
    {
        var insertSql = "INSERT INTO League(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM League WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var league in playerCsvReader.ReadLeague())
                {
                    using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                    checkCommand.Parameters.AddWithValue("@name", league.Name);

                    var exists = (long)checkCommand.ExecuteScalar() > 0;

                    if (!exists)
                    {
                        using var insertCommand = new SqliteCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@name", league.Name);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdateNationality()
    {
        var insertSql = "INSERT INTO Nationality(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Nationality WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var nationality in playerCsvReader.ReadNationality())
                {
                    using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                    checkCommand.Parameters.AddWithValue("@name", nationality.Name);

                    var exists = (long)checkCommand.ExecuteScalar() > 0;

                    if (!exists)
                    {
                        using var insertCommand = new SqliteCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@name", nationality.Name);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdatePlayer()
    {
        var insertSql = "INSERT INTO Player(Name, NationalityId) VALUES (@name, @nationalityId)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Player WHERE Name = @name";
        var selectNationalitySql = "SELECT Id FROM Nationality WHERE Name = @nationality";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var player in playerCsvReader.ReadPlayer())
                {
                    using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                    checkCommand.Parameters.AddWithValue("@name", player.Name);

                    var exists = (long)checkCommand.ExecuteScalar() > 0;

                    if (!exists)
                    {
                        using var selectNationalityCommand = new SqliteCommand(selectNationalitySql, connection);
                        selectNationalityCommand.Parameters.AddWithValue("@nationality", player.Nationality.Name);

                        var nationalityId = (long?)selectNationalityCommand.ExecuteScalar();

                        if (nationalityId.HasValue)
                        {
                            using var insertCommand = new SqliteCommand(insertSql, connection);
                            insertCommand.Parameters.AddWithValue("@name", player.Name);
                            insertCommand.Parameters.AddWithValue("@nationalityId", nationalityId.Value);
                            insertCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            Console.WriteLine($"Nationality '{player.Nationality}' not found.");
                        }
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdatePlaystyle()
    {
        var insertSql = "INSERT INTO Playstyle(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Playstyle WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var playstyle in playerCsvReader.ReadPlaystyle())
                {
                    using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                    checkCommand.Parameters.AddWithValue("@name", playstyle.Name);

                    var exists = (long)checkCommand.ExecuteScalar() > 0;

                    if (!exists)
                    {
                        using var insertCommand = new SqliteCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@name", playstyle.Name);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdateVersion()
    {
        var insertSql = "INSERT INTO Version(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Version WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                foreach (var version in playerCsvReader.ReadVersion())
                {
                    using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                    checkCommand.Parameters.AddWithValue("@name", version.Name);

                    var exists = (long)checkCommand.ExecuteScalar() > 0;

                    if (!exists)
                    {
                        using var insertCommand = new SqliteCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@name", version.Name);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdatePosition()
    {
        var insertSql = "INSERT INTO Position(Name) VALUES (@name)";
        var checkExistenceSql = "SELECT COUNT(*) FROM Position WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                foreach (var positionList in playerCsvReader.ReadPosition())
                {
                    foreach (var position in positionList)
                    {
                        using var checkCommand = new SqliteCommand(checkExistenceSql, connection);
                        checkCommand.Parameters.AddWithValue("@name", position.Name);

                        var exists = (long)checkCommand.ExecuteScalar() > 0;

                        if (!exists)
                        {
                            Console.WriteLine(position.Name);
                            using var insertCommand = new SqliteCommand(insertSql, connection);
                            insertCommand.Parameters.AddWithValue("@name", position.Name);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdateCard()
    {
        // var insertCardSql =
        //     @"INSERT INTO Card(Id, PlayerId, NationalityId, ClubId, LeagueId,VersionId, PositionId, AcceleRateId, 
        //                   OverallRating, DefWR, AttWR, Link, Foot, Height, Weight, WeakFoot) 
        //                   VALUES (@Id, @PlayerId, @NationalityId, @ClubId, @LeagueId, @VersionId, @PositionId, @AcceleRateId, 
        //                   @OverallRating, @DefWR, @AttWR, @Link, @Foot, @Height, @Weight, @WeakFoot)";
        
        var insertCardSql =
            @"INSERT INTO Card(Id, PlayerId, NationalityId, ClubId, LeagueId,VersionId, PositionId, AcceleRateId, 
                          OverallRating, DefWR, AttWR, Link, Foot, Height, Weight, WeakFoot, SkillMoves, Acceleration, 
                          Agression, Age, Agility, Balance, BallControl, Composure, Dribbling, Finishing, Jumping, 
                          LongShots, Penalties, Positioning, Reactions, ShotPower, SlideTackle, SprintSpeed, Stamina, 
                          Strength, Volleys, Price, Crossing, Curve, DEF, DRI, DefAwareness, FKAcc, HeadingAcc, 
                          Interceptions, LongPass, PAC, PAS, PHY, SHO, ShortPass, StandTackle, Vision, DIV, GKDiving, 
                          GKHandling, GKKicking, GKPos, GKReflexes, HAN, KIC, POS, REF, SPD) 
                          VALUES (@Id, @PlayerId, @NationalityId, @ClubId, @LeagueId, @VersionId, @PositionId, @AcceleRateId, 
                          @OverallRating, @DefWR, @AttWR, @Link, @Foot, @Height, @Weight, @WeakFoot, @SkillMoves, 
                          @Acceleration, @Agression, @Age, @Agility, @Balance, @BallControl, @Composure, @Dribbling, 
                          @Finishing, @Jumping, @LongShots, @Penalties, @Positioning, @Reactions, @ShotPower, 
                          @SlideTackle, @SprintSpeed, @Stamina, @Strength, @Volleys, @Price, @Crossing, @Curve, 
                          @DEF, @DRI, @DefAwareness, @FKAcc, @HeadingAcc, @Interceptions, @LongPass, @PAC, @PAS, @PHY, 
                          @SHO, @ShortPass, @StandTackle, @Vision, @DIV, @GKDiving, @GKHandling, @GKKicking, @GKPos, 
                          @GKReflexes, @HAN, @KIC, @POS, @REF, @SPD)";
        
        var checkCardExistenceSql = "SELECT COUNT(*) FROM Card WHERE Id = @Id";
        var selectEntitySql = "SELECT Id FROM {0} WHERE Name = @name";

        try
        {
            using (var connection = new SqliteConnection(connectionString))
{
    connection.Open();

    foreach (var card in playerCsvReader.ReadCard())
    {
        using var checkCommand = new SqliteCommand(checkCardExistenceSql, connection);
        checkCommand.Parameters.AddWithValue("@Id", card.Id);
        
        var exists = (long)checkCommand.ExecuteScalar() > 0;
        
        if (!exists)
        {
            var playerId = GetEntityId(connection, "Player", card.Player.Name);
            var nationalityId = GetEntityId(connection, "Nationality", card.Nationality.Name);
            var clubId = card.Club != null ? GetEntityId(connection, "Club", card.Club.Name) : (object)DBNull.Value;
            var versionId = GetEntityId(connection, "Version", card.Version.Name);
            var positionId = GetEntityId(connection, "Position", card.Position.Name);
            var acceleRateId = card.AcceleRate != null ? GetEntityId(connection, "AcceleRate", card.AcceleRate.Name) : (object)DBNull.Value;
            var leagueId = GetEntityId(connection, "League", card.League.Name);
        
            using var insertCommand = new SqliteCommand(insertCardSql, connection);
            insertCommand.Parameters.AddWithValue("@Id", card.Id);
            insertCommand.Parameters.AddWithValue("@PlayerId", playerId);
            insertCommand.Parameters.AddWithValue("@NationalityId", nationalityId);
            insertCommand.Parameters.AddWithValue("@ClubId", clubId ?? DBNull.Value);
            insertCommand.Parameters.AddWithValue("@LeagueId", leagueId);
            insertCommand.Parameters.AddWithValue("@VersionId", versionId);
            insertCommand.Parameters.AddWithValue("@PositionId", positionId);
            insertCommand.Parameters.AddWithValue("@AcceleRateId", acceleRateId ?? DBNull.Value);
            insertCommand.Parameters.AddWithValue("@OverallRating", card.OverallRating);
            insertCommand.Parameters.AddWithValue("@DefWR", card.DefWr );
            insertCommand.Parameters.AddWithValue("@AttWR", card.AttWr );
            insertCommand.Parameters.AddWithValue("@Link", card.Link);
            insertCommand.Parameters.AddWithValue("@Foot", card.Foot);
            insertCommand.Parameters.AddWithValue("@Height", card.Height);
            insertCommand.Parameters.AddWithValue("@Weight", card.Weight);
            insertCommand.Parameters.AddWithValue("@WeakFoot", card.WeakFoot);
            insertCommand.Parameters.AddWithValue("@SkillMoves", card.SkillMoves);
            insertCommand.Parameters.AddWithValue("@Acceleration", card.Acceleration);
            insertCommand.Parameters.AddWithValue("@Agression", card.Agression);
            insertCommand.Parameters.AddWithValue("@Age", card.Age);
            insertCommand.Parameters.AddWithValue("@Agility", card.Agility.HasValue ? card.Agility.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Balance", card.Balance.HasValue ? card.Balance.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@BallControl", card.BallControl.HasValue ? card.BallControl.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Composure", card.Composure.HasValue ? card.Composure.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Dribbling", card.Dribbling.HasValue ? card.Dribbling.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Finishing", card.Finishing.HasValue ? card.Finishing.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Jumping", card.Jumping.HasValue ? card.Jumping.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@LongShots", card.LongShots.HasValue ? card.LongShots.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Penalties", card.Penalties.HasValue ? card.Penalties.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Positioning", card.Positioning.HasValue ? card.Positioning.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Reactions", card.Reactions.HasValue ? card.Reactions.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@ShotPower", card.ShotPower.HasValue ? card.ShotPower.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@SlideTackle", card.SlideTackle.HasValue ? card.SlideTackle.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@SprintSpeed", card.SprintSpeed.HasValue ? card.SprintSpeed.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Stamina", card.Stamina.HasValue ? card.Stamina.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Strength", card.Strength.HasValue ? card.Strength.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Volleys", card.Volleys.HasValue ? card.Volleys.Value : DBNull.Value);
            insertCommand.Parameters.AddWithValue("@Added", card.Added);
                                insertCommand.Parameters.AddWithValue("@Price",
                            card.Price.HasValue ? card.Price.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@Crossing",
                            card.Crossing.HasValue ? card.Crossing.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@Curve",
                            card.Curve.HasValue ? card.Curve.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@DEF",
                            card.DEF.HasValue ? card.DEF.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@DRI",
                            card.DRI.HasValue ? card.DRI.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@DefAwareness",
                            card.DefAwareness.HasValue ? card.DefAwareness.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@FKAcc",
                            card.FKAcc.HasValue ? card.FKAcc.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@HeadingAcc",
                            card.HeadingAcc.HasValue ? card.HeadingAcc.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@Interceptions",
                            card.Interceptions.HasValue ? card.Interceptions.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@LongPass",
                            card.LongPass.HasValue ? card.LongPass.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@PAC",
                            card.PAC.HasValue ? card.PAC.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@PAS",
                            card.PAS.HasValue ? card.PAS.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@PHY",
                            card.PHY.HasValue ? card.PHY.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@SHO",
                            card.SHO.HasValue ? card.SHO.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@ShortPass",
                            card.ShortPass.HasValue ? card.ShortPass.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@StandTackle",
                            card.StandTackle.HasValue ? card.StandTackle.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@Vision",
                            card.Vision.HasValue ? card.Vision.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@DIV",
                            card.DIV.HasValue ? card.DIV.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@GKDiving",
                            card.GKDiving.HasValue ? card.GKDiving.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@GKHandling",
                            card.GKHandling.HasValue ? card.GKHandling.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@GKKicking",
                            card.GKKicking.HasValue ? card.GKKicking.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@GKPos",
                            card.GKPos.HasValue ? card.GKPos.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@GKReflexes",
                            card.GKReflexes.HasValue ? card.GKReflexes.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@HAN",
                            card.HAN.HasValue ? card.HAN.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@KIC",
                            card.KIC.HasValue ? card.KIC.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@POS",
                            card.POS.HasValue ? card.POS.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@REF",
                            card.REF.HasValue ? card.REF.Value : DBNull.Value);
                        insertCommand.Parameters.AddWithValue("@SPD",
                            card.SPD.HasValue ? card.SPD.Value : DBNull.Value);
            // Print all parameter values before executing the command
            Console.WriteLine("Inserting card with the following parameters:");
            foreach (SqliteParameter parameter in insertCommand.Parameters)
            {
                Console.WriteLine($"{parameter.ParameterName} = {parameter.Value}");
            }
           
            insertCommand.ExecuteNonQuery();
        }
    }
}
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private long? GetEntityId(SqliteConnection connection, string tableName, string name)
    {
        var selectEntitySql = $"SELECT Id FROM {tableName} WHERE Name = @name";
        using var selectCommand = new SqliteCommand(selectEntitySql, connection);
        selectCommand.Parameters.AddWithValue("@name", name);

        return (long?)selectCommand.ExecuteScalar();
    }

    private long? EnsureEntityExists(SqliteConnection connection, string tableName, string name)
    {
        if (name == null) return null;

        var entityId = GetEntityId(connection, tableName, name);
        if (entityId.HasValue) return entityId;

        var insertEntitySql = $"INSERT INTO {tableName}(Name) VALUES (@name); SELECT last_insert_rowid();";
        using var insertCommand = new SqliteCommand(insertEntitySql, connection);
        insertCommand.Parameters.AddWithValue("@name", name);

        return (long?)insertCommand.ExecuteScalar();
    }
}