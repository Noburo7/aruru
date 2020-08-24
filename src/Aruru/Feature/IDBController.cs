using System.Collections.Generic;
using AruruDB;

namespace Aruru
{
    public interface IDBController
    {
        /// <summary>
        /// 馬券タイプテーブル
        /// </summary>
        IEnumerable<IBakenType> BakenTypeTable { get; }

        /// <summary>
        /// レースクラステーブル
        /// </summary>
        IEnumerable<IRaceClass> ClassTable { get; }

        /// <summary>
        /// 馬場状態テーブル
        /// </summary>
        IEnumerable<ITrackCondition> TrackConditionTable { get; }

        /// <summary>
        /// 競馬場テーブル
        /// </summary>
        IEnumerable<ITrack> TrackTable { get; }

        /// <summary>
        /// トラックタイプテーブル
        /// </summary>
        IEnumerable<ITrackType> TrackTypeTable { get; }

        /// <summary>
        /// 距離リストを返す
        /// </summary>
        /// <param name="trackName">競馬場名</param>
        /// <param name="trackType">トラックタイプ名</param>
        /// <returns></returns>
        IEnumerable<int> EnumerateDistance(string trackName, string trackType);
    }
}
