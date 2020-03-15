using System.Collections.Generic;
using AruruDB;

namespace Aruru
{
    public interface IAruruDB
    {
        BakenTypeTable BakenTypeTable { get; }
        RaceClassTable RaceClassTable { get; }
        TrackConditionTable TrackConditionTable { get; }
        TrackTable TrackTable { get; }
        TrackTypeTable TrackTypeTable { get; }
        CourseTable CourseTable { get; }
        RaceTable RaceTable { get; }
        BakenTable BakenTable { get; }

        /// <summary>
        /// すべてのテーブルをロードする。
        /// </summary>
        void LoadAruruDB();

        /// <summary>
        /// DBに登録されている馬券情報リストを返す。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBaken> GenerateBakenList();
    }
}
