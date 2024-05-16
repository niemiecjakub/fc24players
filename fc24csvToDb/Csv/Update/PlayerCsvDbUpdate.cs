    using Microsoft.Data.Sqlite;

    namespace fc24csvToDb.Csv.Update;

    public class PlayerCsvDbUpdate(string connectionString, IPlayerCsvReader playerCsvReader) : IPlayerCsvDbUpdate
    {
        public void UpdateAll()
        {
            UpdateAcceleRate();
            // UpdateBodytype();
            UpdateClub();
            UpdateLeague();
            UpdateNationality();
            UpdatePlaystyle();
            UpdateVersion();
            UpdatePosition();
            UpdatePosition();
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
        

        public void UpdateCard()
        {
            throw new NotImplementedException();
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
                            
                            // using var insertCommand = new SqliteCommand(insertSql, connection);
                            // insertCommand.Parameters.AddWithValue("@name", player.Name);
                            // insertCommand.Parameters.AddWithValue("@nationality", nationality);
                            // insertCommand.ExecuteNonQuery();
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

    }