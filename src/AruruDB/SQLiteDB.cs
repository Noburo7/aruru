using System.Collections.Generic;
using System.Data.SQLite;

namespace AruruDB
{
    /// <summary>
    /// SQLiteDBクラス
    /// </summary>
    public class SQLiteDB
    {
        public string DBFileName { get; }

        public SQLiteDB(string sqliteFileNm) {
            DBFileName = sqliteFileNm;
        }

        /// <summary>
        /// テーブルを作成する。
        /// </summary>
        /// <returns></returns>
        public bool CreateTable() {
            try {
                SQLiteConnection.CreateFile(DBFileName);
                return true;
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// sqlを実行し、結果をIEnumerable<string[]>で返す。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<string[]> Execute(string sql) {
            var result = new List<string[]>();
            try {
                var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = DBFileName };
                using (var con = new SQLiteConnection(sqlConnectionSb.ToString())) {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con)) {
                        cmd.CommandText = sql;
                        var res = cmd.ExecuteReader();
                        while (res.Read()) {
                            string[] column = new string[res.FieldCount];
                            for (var j = 0; j < res.FieldCount; j++) {
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
