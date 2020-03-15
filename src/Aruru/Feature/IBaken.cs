using System;
using System.Collections.Generic;

namespace Aruru
{
    /// <summary>
    /// 馬券インターフェース
    /// </summary>
    public interface IBaken
    {
        /// <summary>
        /// 購入レースID(DB用)
        /// </summary>
        int RaceID { get; }

        /// <summary>
        /// レース日
        /// </summary>
        DateTime Date { get; }

        /// <summary>
        /// 競馬場名
        /// </summary>
        string TrackName { get; }

        /// <summary>
        /// レース番号
        /// </summary>
        int RaceNum { get; }

        /// <summary>
        /// レース名
        /// </summary>
        string RaceName { get; }

        /// <summary>
        /// 芝・ダ
        /// </summary>
        string TrackType { get; }

        /// <summary>
        /// 距離
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// クラス
        /// </summary>
        string Class { get; }

        /// <summary>
        /// 馬場状態
        /// </summary>
        string TrackCondition { get; }

        /// <summary>
        /// ハンデ戦フラグ
        /// </summary>
        bool IsHandicap { get; }

        /// <summary>
        /// 牝馬限定戦フラグ
        /// </summary>
        bool IsOnlyFemale { get; }

        /// <summary>
        /// ２・３歳戦フラグ
        /// </summary>
        bool IsOnlyYouth { get; }

        /// <summary>
        /// 馬券収支情報
        /// </summary>
        IEnumerable<IBet> Bettings { get; }
    }
}
