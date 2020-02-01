using System;
using System.IO;
using System.Data.SQLite;

namespace AruruDB
{
    public class SQL
    {
        private string _filePath;
        private string _dbName;

        public SQL(string filePath, string dbName) {
            _filePath = filePath;
            _dbName = dbName;
        }

        public bool Execute() {
            try {
                var sql = File.ReadAllText(_filePath);
                var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = _dbName };
                using (var con = new SQLiteConnection(sqlConnectionSb.ToString())) {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con)) {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch {
                throw;
            }
        }
    }
}
