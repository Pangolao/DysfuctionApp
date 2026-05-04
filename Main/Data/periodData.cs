using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace Dysfunction.Data
{
    public class periodData
    {
        private string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "periods.db");

        public periodData()
        {
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"));
            }

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Periods (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Year INTEGER,
                                            Period TEXT,
                                            StartDate TEXT,
                                            EndDate TEXT,
                                            Asignatures TEXT)";
                SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        public void AddNew(periodModel period)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                string insertQuery = @"INSERT INTO Periods (Year, Period, StartDate, EndDate, Asignatures) 
                                       VALUES (@Year, @Period, @StartDate, @EndDate, @Asignatures)";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", period.Year);
                    command.Parameters.AddWithValue("@Period", period.Period);
                    command.Parameters.AddWithValue("@StartDate", period.StartDate.ToString("O")); // ISO 8601 format
                    command.Parameters.AddWithValue("@EndDate", period.EndDate.ToString("O"));
                    command.Parameters.AddWithValue("@Asignatures", string.Join("||", period.Asignatures));

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Edit(periodModel period)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                string updateQuery = @"
        UPDATE Periods
        SET StartDate = @StartDate, EndDate = @EndDate, Asignatures = @Asignatures
        WHERE Year = @Year AND Period = @Period";

                using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", period.Year);
                    command.Parameters.AddWithValue("@Period", period.Period);
                    command.Parameters.AddWithValue("@StartDate", period.StartDate.ToString("O")); // ISO 8601 format
                    command.Parameters.AddWithValue("@EndDate", period.EndDate.ToString("O"));
                    command.Parameters.AddWithValue("@Asignatures", string.Join("||", period.Asignatures));

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(periodModel period)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                string deleteQuery = @"
        DELETE FROM Periods
        WHERE Year = @Year AND Period = @Period";

                using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", period.Year);
                    command.Parameters.AddWithValue("@Period", period.Period);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<periodModel> ConsultBD()
        {
            List<periodModel> periods = new List<periodModel>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                string selectQuery = "SELECT Year, Period, StartDate, EndDate, Asignatures FROM Periods";

                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int year = reader.GetInt32(0);
                        string period = reader.GetString(1);

                        // Parsear fechas con el formato específico "dd/MM/yyyy"
                        DateTime startDate = DateTime.Parse(reader.GetString(2), null, DateTimeStyles.RoundtripKind);
                        DateTime endDate = DateTime.Parse(reader.GetString(3), null, DateTimeStyles.RoundtripKind);

                        List<string> asignatures = new List<string>(reader.GetString(4).Split(new string[] { "||" }, StringSplitOptions.None));

                        periodModel periodModel = new periodModel(year, period, startDate, endDate, asignatures);
                        periods.Add(periodModel);
                    }
                }
            }

            return periods;
        }
    }
}
