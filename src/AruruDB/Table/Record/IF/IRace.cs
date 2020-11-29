namespace AruruDB.Table.Record
{
    /// <summary>
    /// レース属性
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// レースID
        /// </summary>
        int ID { get; }

        /// <summary>
        /// レース日
        /// </summary>
        string Date { get; }

        /// <summary>
        /// 競馬場ID
        /// </summary>
        int TrackID { get; }

        /// <summary>
        /// レース番号
        /// </summary>
        int RaceNumber { get; }

        /// <summary>
        /// レース名
        /// </summary>
        string RaceName { get; }

        /// <summary>
        /// 芝・ダ
        /// </summary>
        int TrackTypeID { get; }

        /// <summary>
        /// 距離
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// クラス
        /// </summary>
        int RaceClassID { get; }

        /// <summary>
        /// 馬場状態
        /// </summary>
        int TrackConditionID { get; }

        /// <summary>
        /// ハンデ戦フラグ
        /// </summary>
        int IsHandicap { get; }

        /// <summary>
        /// 牝馬限定戦フラグ
        /// </summary>
        int IsOnlyFemale { get; }

        /// <summary>
        /// 2・3歳戦フラグ
        /// </summary>
        int IsOnlyYouth { get; }
    }
}
