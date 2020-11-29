namespace AruruDB.Table.Record
{
    /// <summary>
    /// レースクラス
    /// </summary>
    public interface IClassRecord
    {
        /// <summary>
        /// レースクラスID
        /// </summary>
        int ID { get; }

        /// <summary>
        /// クラス名
        /// </summary>
        string Name { get; }
    }
}
