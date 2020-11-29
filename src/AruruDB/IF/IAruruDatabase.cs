using System.Collections.Generic;

namespace AruruDB
{
    /// <summary>
    /// AruruDB
    /// </summary>
    public interface IAruruDatabase
    {
        /// <summary>
        /// データベースを初期化する
        /// </summary>
        void Init();

        /// <summary>
        /// 馬券種別テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBakenType> ReadBakenTypeTable();

        /// <summary>
        /// レースクラステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRaceClass> ReadRaceClassTable();

        /// <summary>
        /// 馬場状態テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITrackCondition> ReadTrackConditionTable();

        /// <summary>
        /// 競馬場テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITrack> ReadTrackTable();

        /// <summary>
        /// トラックタイプテーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITrackType> ReadTrackTypeTable();

        /// <summary>
        /// レーステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRace> ReadRaceTable();

        /// <summary>
        /// 馬券テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBaken> ReadBakenTable();

        /// <summary>
        /// 競馬場・トラックタイプに対する距離リストを返す。
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> ReadDistanceList(int trackID, int trackTypeID);
    }
}
