using System;
using System.Collections.Generic;

namespace Aruru
{
    /// <summary>
    /// 馬券クラス
    /// </summary>
    public class Baken : IBaken
    {
        /// <summary>
        /// 購入レースID(DB用)
        /// </summary>
        public int RaceID { get; set; }

        /// <summary>
        /// レース日
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 競馬場名
        /// </summary>
        public string TrackName { get; set; }

        /// <summary>
        /// レース番号
        /// </summary>
        public int RaceNum { get; set; }

        /// <summary>
        /// レース名
        /// </summary>
        public string RaceName { get; set; }

        /// <summary>
        /// 芝・ダ
        /// </summary>
        public string TrackType { get; set; }

        /// <summary>
        /// 距離
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// クラス
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 馬場状態
        /// </summary>
        public string TrackCondition { get; set; }

        /// <summary>
        /// ハンデ戦フラグ
        /// </summary>
        public bool IsHandicap { get; set; }

        /// <summary>
        /// 牝馬限定戦フラグ
        /// </summary>
        public bool IsOnlyFemale { get; set; }

        /// <summary>
        /// ２・３歳戦フラグ
        /// </summary>
        public bool IsOnlyYouth { get; set; }

        /// <summary>
        /// 馬券収支情報
        /// </summary>
        public IEnumerable<IBet> Bettings { get; set; }
    }
}
