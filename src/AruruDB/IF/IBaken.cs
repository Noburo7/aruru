namespace AruruDB
{
    public interface IBaken
    {
        /// <summary>
        /// 馬券種別
        /// </summary>
        string BakenTypeNm { get; }

        /// <summary>
        /// 投資金額
        /// </summary>
        int Investment { get; }

        /// <summary>
        /// 購入金額
        /// </summary>
        int Payout { get; }
    }
}
