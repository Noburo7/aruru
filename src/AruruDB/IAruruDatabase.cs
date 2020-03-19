using System.Collections.Generic;

namespace AruruDB
{
    /// <summary>
    /// AruruDB
    /// </summary>
    public interface IAruruDatabase
    {
        /// <summary>
        /// 馬券種別テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBakenType> LoadBakenTypeTable();

        /// <summary>
        /// レースクラステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRaceClass> LoadRaceClassTable();

        /// <summary>
        /// 馬場状態テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITrackCondition> LoadTrackConditionTable();

        /// <summary>
        /// 競馬場テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITrack> LoadTrackTable();

        /// <summary>
        /// トラックタイプテーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITrackType> LoadTrackTypeTable();

        /// <summary>
        /// レーステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRace> LoadRaceTable();

        /// <summary>
        /// 馬券テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBaken> LoadBakenTable();

        /// <summary>
        /// 競馬場・トラックタイプに対する距離リストを返す。
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> LoadDistanceList(int trackID, int trackTypeID);
    }
}
