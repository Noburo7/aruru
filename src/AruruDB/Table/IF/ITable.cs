namespace AruruDB.Table
{
    public interface ITable
    {
        /// <summary>
        /// SQLLiteDB
        /// </summary>
        ISQLiteDB SQLiteDB { get; }
        
        /// <summary>
        /// テーブルを初期化する
        /// </summary>
        void Init();

        /// <summary>
        /// テーブルを読み込む
        /// </summary>
        void ReadTable();
    }
}
