namespace AruruDB
{
    /// <summary>
    /// レースクラス
    /// </summary>
    public interface IRaceClass
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
