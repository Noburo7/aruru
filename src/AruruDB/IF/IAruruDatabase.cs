﻿using AruruDB.Table;
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

        IEnumerable<int> DistanceList(string trackNm, string trackTypeNm);
    }
}
