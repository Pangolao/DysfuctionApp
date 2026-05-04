using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Dysfunction.Data
{
    public class asignatureData
    {
        private string connectionString;

        public asignatureData()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string dbPath = Path.Combine(folderPath, "asignatures.db");
            connectionString = $"Data Source={dbPath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS asignatures (
                        Period TEXT,
                        Code TEXT PRIMARY KEY,
                        Asignature TEXT,
                        Teacher TEXT,
                        GroupCode TEXT,
                        Approved BOOLEAN
                    );";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddNew(asignatureModel asignature)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO asignatures (Period, Code, Asignature, Teacher, GroupCode, Approved)
                    VALUES ( @Period, @Code, @Asignature, @Teacher, @GroupCode, @Approved);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Period", asignature.Period);
                    command.Parameters.AddWithValue("@Code", asignature.Code);
                    command.Parameters.AddWithValue("@Asignature", asignature.Asignature);
                    command.Parameters.AddWithValue("@Teacher", asignature.Teacher);
                    command.Parameters.AddWithValue("@GroupCode", asignature.Group);
                    command.Parameters.AddWithValue("@Approved", asignature.Approved);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(asignatureModel asignature)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"
                    UPDATE asignatures
                    SET Period = @Period, Asignature = @Asignature,
                        Teacher = @Teacher, GroupCode = @GroupCode, Approved = @Approved
                    WHERE Code = @Code;";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Period", asignature.Period);
                    command.Parameters.AddWithValue("@Code", asignature.Code);
                    command.Parameters.AddWithValue("@Asignature", asignature.Asignature);
                    command.Parameters.AddWithValue("@Teacher", asignature.Teacher);
                    command.Parameters.AddWithValue("@GroupCode", asignature.Group);
                    command.Parameters.AddWithValue("@Approved", asignature.Approved);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(asignatureModel asignature)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = @"
            DELETE FROM asignatures
            WHERE Code = @Code;"; // Solo el parámetro @Code es necesario
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Code", asignature.Code); // Solo agregar Code
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<asignatureModel> ConsultBD()
        {
            List<asignatureModel> asignatures = new List<asignatureModel>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM asignatures;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string period = reader.IsDBNull(0) ? null : reader.GetString(1);
                            string code = reader.GetString(1);
                            string asignature = reader.GetString(2);
                            string teacher = reader.GetString(3);
                            string group = reader.GetString(4);
                            bool approved = reader.GetBoolean(5);

                            asignatures.Add(new asignatureModel( period, code, asignature, teacher, group, approved));
                        }
                    }
                }
            }
            return asignatures;
        }
    }
}
