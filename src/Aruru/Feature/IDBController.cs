using System.Collections.Generic;

namespace Aruru
{
    public interface IDBController
    {
        /// <summary>
        /// 馬券種別名を列挙する。
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> EnumerateBakenTypeNames();

        /// <summary>
        /// クラス名を列挙する。
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> EnumerateClassNames();

        /// <summary>
        /// 馬場状態名を列挙する。
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> EnumerateTrackConditionNames();

        /// <summary>
        /// 競馬場名を列挙する。
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> EnumerateTrackNames();

        /// <summary>
        /// トラックタイプ名を列挙する。
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> EnumerateTrackTypeNames();

        /// <summary>
        /// 距離リストを返す
        /// </summary>
        /// <param name="trackName">競馬場名</param>
        /// <param name="trackType">トラックタイプ名</param>
        /// <returns></returns>
        IEnumerable<int> EnumerateDistance(string trackName, string trackType);
    }
}
