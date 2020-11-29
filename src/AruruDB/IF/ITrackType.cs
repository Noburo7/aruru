namespace AruruDB
{
    /// <summary>
    /// トラックタイプ
    /// </summary>
    public interface ITrackType
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
