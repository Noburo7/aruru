using System.Collections.Generic;

namespace AruruDB.DBCreator
{
    /// <summary>
    /// AruruDB作成用インターフェイス
    /// </summary>
    public interface ICreator
    {
        /// <summary>
        /// AruruDBテーブルを作成する。
        /// </summary>
        void CreateTable();

        /// <summary>
        /// AruruDBに対しSQLコマンドを実行する。
        /// </summary>
        /// <param name="sql"></param>
        IEnumerable<string[]> ExecuteSql(string sql);
    }
}
