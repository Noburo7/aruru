using AruruDB.Table;
using System.Collections.Generic;

namespace AruruDB
{
    /// <summary>
    /// AruruDB
    /// </summary>
    public interface IAruruDatabase
    {
        /// <summary>
        /// 馬券テーブル
        /// </summary>
        IBakenTable BakenTable { get; }

        /// <summary>
        /// 馬券種テーブル
        /// </summary>
        IBakenTypeTable BakenTypeTable { get; }

        /// <summary>
        /// コーステーブル
        /// </summary>
        ICourseTable CourseTable { get; }

        /// <summary>
        /// レースクラステーブル
        /// </summary>
        IRaceClassTable RaceClassTable { get; }

        /// <summary>
        /// レーステーブル
        /// </summary>
        IRaceTable RaceTable { get; }

        /// <summary>
        /// 馬場状態テーブル
        /// </summary>
        ITrackConditionTable TrackConditionTable { get; }

        /// <summary>
        /// 競馬場テーブル
        /// </summary>
        ITrackTable TrackTable { get; }

        /// <summary>
        /// コースタイプテーブル
        /// </summary>
        ITrackTypeTable TrackTypeTable { get; }

        /// <summary>
        /// 備考テーブル
        /// </summary>
        IRemarkTable RemarkTable { get; }

        /// <summary>
        /// コースの距離リストを返す
        /// </summary>
        /// <param name="trackNm">競馬場名</param>
        /// <param name="trackTypeNm">馬場タイプ</param>
        /// <returns>距離リスト</returns>
        IEnumerable<int> DistanceList(string trackNm, string trackTypeNm);

        /// <summary>
        /// レース・馬券を登録する
        /// </summary>
        /// <param name="baken"></param>
        void InsertBakenResult(IRace raceInfo, IEnumerable<IBaken> baken);

        /// <summary>
        /// レースIDを返す
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="trackNm">競馬場名</param>
        /// <param name="raceNum">レース番号</param>
        /// <returns>レースID</returns>
        int GetRaceID(string date, string trackNm, int raceNum);

        void DeleteRaceBakenRecord(string date, string trackNm, int raceNum);
    }
}
