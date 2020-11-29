namespace AruruDB.Table.Record
{
    /// <summary>
    /// 馬券収支
    /// </summary>
    public interface IBaken
    {
        /// <summary>
        /// 馬券ID
        /// </summary>
        int BakenID { get; }

        /// <summary>
        /// レースID
        /// </summary>
        int RaceID { get; }

        /// <summary>
        /// 馬券種別
        /// </summary>
        int BakenTypeID { get; }

        /// <summary>
        /// 投資金額
        /// </summary>
        int Investment { get; }

        /// <summary>
        /// 払戻金額
        /// </summary>
        int Payout { get; }
    }
}
