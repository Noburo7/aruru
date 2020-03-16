using System.Collections.Generic;

namespace AruruDB.DBCreator
{
    public class Creator : ICreator
    {
        private string _dbName;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbName"></param>
        public Creator(string dbName)
        {
            _dbName = dbName;
        }

        /// <summary>
        /// AruruDBテーブルを作成する。
        /// </summary>
        public void CreateTable()
        {
            new SQLiteDB(_dbName).CreateTable();
        }

        /// <summary>
        /// AruruDBに対しSQLコマンドを実行する。
        /// </summary>
        /// <param name="sql"></param>
        public IEnumerable<string[]> ExecuteSql(string sql)
        {
            return new SQLiteDB(_dbName).Execute(sql);
        }
    }
}
