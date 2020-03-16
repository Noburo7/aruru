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
        /// コーステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICourse> LoadCourseTable();

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
    }
}
