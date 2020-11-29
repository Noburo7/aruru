namespace AruruDB.Table.Record
{
    /// <summary>
    /// トラックタイプ
    /// </summary>
    public interface ITrackTypeRecord
    {
        /// <summary>
        /// トラックタイプID
        /// </summary>
        int ID { get; }

        /// <summary>
        /// 芝・ダ
        /// </summary>
        string Name { get; }
    }
}
