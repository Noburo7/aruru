namespace AruruDB
{
    /// <summary>
    /// 馬場状態
    /// </summary>
    public interface ITrackCondition
    {
        /// <summary>
        /// 馬場状態ID
        /// </summary>
        int ID { get; }

        /// <summary>
        /// 馬場状態名
        /// </summary>
        string Name { get; }
    }
}
