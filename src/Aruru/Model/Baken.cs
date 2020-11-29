using AruruDB;

namespace Aruru
{
    /// <summary>
    /// 馬券クラス
    /// </summary>
    public class Baken : IBaken
    {
        /// <summary>
        /// 馬券種別
        /// </summary>
        public string BakenTypeNm { get; set; }

        /// <summary>
        /// 投資金額
        /// </summary>
        public int Investment { get; set; }

        /// <summary>
        /// 購入金額
        /// </summary>
        public int Payout { get; set; }
    }
}
