using System.Collections.Generic;

namespace AruruDB
{
    public class AruruDatabase : IAruruDatabase
    {
        private string _DBName;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbName"></param>
        public AruruDatabase(string dbName)
        {
            _DBName = dbName;
        }

        /// <summary>
        /// 馬券種別テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBakenType> LoadBakenTypeTable()
        {
            return new BakenTypeTable(_DBName).LoadTable();
        }

        /// <summary>
        /// レースクラステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRaceClass> LoadRaceClassTable()
        {
            return new RaceClassTable(_DBName).LoadTable();
        }

        /// <summary>
        /// 馬場状態テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrackCondition> LoadTrackConditionTable()
        {
            return new TrackConditionTable(_DBName).LoadTable();
        }

        /// <summary>
        /// 競馬場テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrack> LoadTrackTable()
        {
            return new TrackTable(_DBName).LoadTable();
        }

        /// <summary>
        /// トラックタイプテーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrackType> LoadTrackTypeTable()
        {
            return new TrackTypeTable(_DBName).LoadTable();
        }

        /// <summary>
        /// レーステーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRace> LoadRaceTable()
        {
            return new RaceTable(_DBName).LoadTable();
        }

        /// <summary>
        /// 馬券テーブルをロードする。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBaken> LoadBakenTable()
        {
            return new BakenTable(_DBName).LoadTable();
        }

        /// <summary>
        /// 競馬場・トラックタイプに対する距離リストを返す。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> LoadDistanceList(int trackID, int trackTypeID)
        {
            return new CourseTable(_DBName).LoadDistance(trackID, trackTypeID);
        }
    }
}
