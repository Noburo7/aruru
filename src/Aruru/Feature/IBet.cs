namespace Aruru
{
    /// <summary>
    /// 馬券収支インターフェース
    /// </summary>
    public interface IBet
    {
        /// <summary>
        /// 管理ID(DB用)
        /// </summary>
        int ID { get; }

        /// <summary>
        /// 馬券種別
        /// </summary>
        int TypeID { get; }

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
