namespace AruruDB.Table.Record
{
    /// <summary>
    /// 競馬場
    /// </summary>
    public interface ITrackRecord
    {
        /// <summary>
        /// 競馬場ID
        /// </summary>
        int ID { get; }

        /// <summary>
        /// 競馬場名
        /// </summary>
        string Name { get; }

        int IsUnique { get; }
    }
}
