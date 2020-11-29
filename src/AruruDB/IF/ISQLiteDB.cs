using System;
using System.Collections.Generic;
using System.Text;

namespace AruruDB
{
    /// <summary>
    /// SQLiteデータベースインターフェイス
    /// </summary>
    public interface ISQLiteDB
    {
        /// <summary>
        /// SQLiteDBファイルを作成する。
        /// </summary>
        /// <returns></returns>
        void CreateDBFile();

        /// <summary>
        /// sqlを実行し、結果をIEnumerable<string[]>で返す。
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        IEnumerable<string[]> ExecuteSql(string sql);
    }
}
