using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace Dysfunction.Data
{
    public class projectData
    {
        private string connectionString;

        public projectData()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string dbPath = Path.Combine(folderPath, "projects.db");
            connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS projects (
                                            Year INTEGER,
                                            Period TEXT,
                                            Code TEXT,
                                            Project TEXT,
                                            Value REAL,
                                            Score REAL,
                                            LimitDate TEXT,
                                            PRIMARY KEY(Year, Period, Code, Project))";
                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddNew(projectModel project)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"INSERT OR REPLACE INTO projects 
                                       (Year, Period, Code, Project, Value, Score, LimitDate) 
                                       VALUES (@Year, @Period, @Code, @Project, @Value, @Score, @LimitDate)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", project.Year);
                    command.Parameters.AddWithValue("@Period", project.Period);
                    command.Parameters.AddWithValue("@Code", project.Code);
                    command.Parameters.AddWithValue("@Project", project.Project);
                    command.Parameters.AddWithValue("@Value", project.Value);
                    command.Parameters.AddWithValue("@Score", project.Score);
                    command.Parameters.AddWithValue("@LimitDate", project.LimitDate.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(List<projectModel> projects)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                foreach (var project in projects)
                {
                    string insertQuery = @"INSERT OR REPLACE INTO projects 
                                           (Year, Period, Code, Project, Value, Score, LimitDate) 
                                           VALUES (@Year, @Period, @Code, @Project, @Value, @Score, @LimitDate)";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Year", project.Year);
                        command.Parameters.AddWithValue("@Period", project.Period);
                        command.Parameters.AddWithValue("@Code", project.Code);
                        command.Parameters.AddWithValue("@Project", project.Project);
                        command.Parameters.AddWithValue("@Value", project.Value);
                        command.Parameters.AddWithValue("@Score", project.Score);
                        command.Parameters.AddWithValue("@LimitDate", project.LimitDate.ToString("yyyy-MM-dd"));

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public void Edit(projectModel project)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"
                    UPDATE projects
                    SET Year = @Year, Period = @Period, Code = @Code,
                        Project = @Project, Value = @Value, Score = @Score, LimitDate = @LimitDate
                    WHERE Code = @Code AND Year = @Year AND Period = @Period AND Project = @Project;";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                         command.Parameters.AddWithValue("@Year", project.Year);
                        command.Parameters.AddWithValue("@Period", project.Period);
                        command.Parameters.AddWithValue("@Code", project.Code);
                        command.Parameters.AddWithValue("@Project", project.Project);
                        command.Parameters.AddWithValue("@Value", project.Value);
                        command.Parameters.AddWithValue("@Score", project.Score);
                        command.Parameters.AddWithValue("@LimitDate", project.LimitDate.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(projectModel project)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"
                    DELETE FROM projects
                    WHERE Code = @Code AND Year = @Year AND Period = @Period AND Project = @Project;";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", project.Year);
                    command.Parameters.AddWithValue("@Period", project.Period);
                    command.Parameters.AddWithValue("@Code", project.Code);
                    command.Parameters.AddWithValue("@Project", project.Project);
                    command.Parameters.AddWithValue("@Value", project.Value);
                    if (project.Score != null)
                    {
                        command.Parameters.AddWithValue("@Score", project.Score);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Score", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@LimitDate", project.LimitDate.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteSpecs(int year, string period, string code)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = @"
            DELETE FROM projects
            WHERE Year = @Year AND Period = @Period AND Code = @Code;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Period", period);
                    command.Parameters.AddWithValue("@Code", code);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<projectModel> ConsultBD()
        {
            List<projectModel> projects = new List<projectModel>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Year, Period, Code, Project, Value, Score, LimitDate FROM projects";
                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int year = reader.GetInt32(0);
                            string period = reader.GetString(1);
                            string code = reader.GetString(2);
                            string project = reader.GetString(3);
                            float value = reader.GetFloat(4);
                            float score = reader.GetFloat(5);
                            DateTime limitDate = DateTime.Parse(reader.GetString(6), CultureInfo.CurrentCulture);

                            projects.Add(new projectModel(year, period, code, project, value, score, limitDate));
                        }
                    }
                }
            }

            return projects;
        }
    }
}

