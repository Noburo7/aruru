namespace AruruDB
{
    /// <summary>
    /// レース情報インターフェイス
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// 日付(hhhhyydd)
        /// </summary>
        string Date { get; }

        /// <summary>
        /// 競馬場名
        /// </summary>
        string TrackNm { get; }

        /// <summary>
        /// レース番号
        /// </summary>
        int RaceNum { get; }

        /// <summary>
        /// レース名
        /// </summary>
        string RaceNm { get; }

        /// <summary>
        /// トラックタイプ名(芝/ダ)
        /// </summary>
        string TrackTypeID { get; }

        /// <summary>
        /// 距離
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// クラス名
        /// </summary>
        string RaceClassNm { get; }

        /// <summary>
        /// 馬場状態名
        /// </summary>
        string TrackConditionNm { get; }

        /// <summary>
        /// ハンディキャップ競争フラグ
        /// </summary>
        bool IsHandicap { get; }

        /// <summary>
        /// 牝馬限定競争フラグ
        /// </summary>
        bool IsOnlyFemale { get; }

        /// <summary>
        /// ２・３歳戦競争フラグ
        /// </summary>
        bool IsOnlyYouth { get; }
    }
}
