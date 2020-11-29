using AruruDB;

namespace Aruru
{
    public class Race : IRace
    {
        /// <summary>
        /// 日付(hhhhyydd)
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 競馬場名
        /// </summary>
        public string TrackNm { get; set; }

        /// <summary>
        /// レース番号
        /// </summary>
        public int RaceNum { get; set; }

        /// <summary>
        /// レース名
        /// </summary>
        public string RaceNm { get; set; }

        /// <summary>
        /// トラックタイプ名(芝/ダ)
        /// </summary>
        public string TrackTypeNm { get; set; }

        /// <summary>
        /// 距離
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// クラス名
        /// </summary>
        public string RaceClassNm { get; set; }

        /// <summary>
        /// 馬場状態名
        /// </summary>
        public string TrackConditionNm { get; set; }

        /// <summary>
        /// ハンディキャップ競争フラグ
        /// </summary>
        public bool IsHandicap { get; set; }

        /// <summary>
        /// 牝馬限定競争フラグ
        /// </summary>
        public bool IsOnlyFemale { get; set; }

        /// <summary>
        /// ２・３歳戦競争フラグ
        /// </summary>
        public bool IsOnlyYouth { get; set; }
    }
}
