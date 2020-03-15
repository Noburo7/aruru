namespace Aruru
{
    /// <summary>
    /// 馬券収支クラス
    /// </summary>
    internal class Bet : IBet
    {
        /// <summary>
        /// 管理ID(DB用)
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// 馬券種別
        /// </summary>
        public int TypeID { get; set; }

        /// <summary>
        /// 投資金額
        /// </summary>
        public int Investment { get; set; }

        /// <summary>
        /// 払戻金額
        /// </summary>
        public int Payout { get; set; }
    }
}