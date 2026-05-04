using Dysfunction.Model;
using System.Data.SQLite;
using System.Globalization;

namespace Dysfunction.Data
{
    public class eventsData
    {
        private string connectionString;

        public eventsData()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string dbPath = Path.Combine(folderPath, "events.db");
            connectionString = $"Data Source={dbPath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS events (
                        Name TEXT,
                        Description TEXT,
                        Id TEXT PRIMARY KEY,
                        StarDate TEXT,
                        EndDate TEXT,
                        Hour TEXT
                    );";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddNew(eventsModel events)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = @"
            INSERT INTO events (Name, Description, Id, StarDate, EndDate, Hour)
            VALUES (@Name, @Description, @Id, @StarDate, @EndDate,@Hour);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", events.Name);
                    command.Parameters.AddWithValue("@Description", events.Description);
                    command.Parameters.AddWithValue("@Id", events.Id);
                    command.Parameters.AddWithValue("@StarDate", events.StartDate);
                    if (events.EndDate.HasValue)
                        command.Parameters.AddWithValue("@EndDate", events.EndDate.Value);
                    else
                        command.Parameters.AddWithValue("@EndDate", DBNull.Value);

                    if (events.Hour.HasValue)
                        command.Parameters.AddWithValue("@Hour", events.Hour.Value);
                    else
                        command.Parameters.AddWithValue("@Hour", DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(eventsModel events)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"
            UPDATE events
            SET Name = @Name, Description = @Description, Id = @Id,
                StarDate = @StarDate, EndDate = @EndDate, Hour = @Hour
            WHERE Name = @Name;";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", events.Name);
                    command.Parameters.AddWithValue("@Description", events.Description);
                    command.Parameters.AddWithValue("@Id", events.Id);
                    command.Parameters.AddWithValue("@StarDate", events.StartDate);

                    if (events.EndDate.HasValue)
                        command.Parameters.AddWithValue("@EndDate", events.EndDate.Value);
                    else
                        command.Parameters.AddWithValue("@EndDate", DBNull.Value);

                    if (events.Hour.HasValue)
                        command.Parameters.AddWithValue("@Hour", events.Hour.Value);
                    else
                        command.Parameters.AddWithValue("@Hour", DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(eventsModel events)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = @"
                DELETE FROM events
                 WHERE Name = @Name;";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", events.Name);
                    command.Parameters.AddWithValue("@Description", events.Description);
                    command.Parameters.AddWithValue("@StarDate", events.StartDate);

                    if (events.EndDate.HasValue)
                        command.Parameters.AddWithValue("@EndDate", events.EndDate.Value);
                    else
                        command.Parameters.AddWithValue("@EndDate", DBNull.Value);

                    if (events.Hour.HasValue)
                        command.Parameters.AddWithValue("@Hour", events.Hour.Value);
                    else
                        command.Parameters.AddWithValue("@Hour", DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<eventsModel> ConsultBD()
        {
            List<eventsModel> events = new List<eventsModel>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM events;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string description = reader.GetString(1);
                            string id = reader.GetString(2);

                            DateTime startDate = DateTime.Parse(reader.GetString(3), CultureInfo.CurrentCulture);

                            DateTime? endDate = reader.IsDBNull(4)
                                ? (DateTime?)null
                                : DateTime.Parse(reader.GetString(4), CultureInfo.CurrentCulture);

                            TimeSpan? hour = reader.IsDBNull(5)
                                ? (TimeSpan?)null
                                : TimeSpan.Parse(reader.GetString(5));

                            events.Add(new eventsModel(id, name, description, startDate, endDate, hour));
                        }
                    }
                }
            }
            return events;
        }
    }
}