using System.Collections.Generic;
using System.Data.SQLite;

namespace AruruDB
{
    /// <summary>
    /// SQLiteDBクラス
    /// </summary>
    internal class SQLiteDB : ISQLiteDB
    {
        private string _sqliteFileName;

        public SQLiteDB(string sqliteFileNm)
        {
            _sqliteFileName = sqliteFileNm;
        }

        /// <summary>
        /// SQLiteDBファイルを作成する。
        /// </summary>
        /// <returns></returns>
        public void CreateDBFile()
        {
            try
            {
                SQLiteConnection.CreateFile(_sqliteFileName);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// sqlを実行し、結果をIEnumerable<string[]>で返す。
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public IEnumerable<string[]> ExecuteSql(string sql)
        {
            var result = new List<string[]>();
            try
            {
                var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = _sqliteFileName };
                using (var con = new SQLiteConnection(sqlConnectionSb.ToString()))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = sql;
                        var res = cmd.ExecuteReader();
                        while (res.Read())
                        {
                            string[] column = new string[res.FieldCount];
                            for (var j = 0; j < res.FieldCount; j++)
                            {
                                column[j] = res[j].ToString();
                            }
                            result.Add(column);
                        }
                    }
                }
                return result;
            }
            catch {
                throw;
            }
        }
    }
}
